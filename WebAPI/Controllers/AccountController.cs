using Application.Features.AccountFeatures.Commands.AddUserToRole;
using Application.Features.AccountFeatures.Commands.ChangePassword;
using Application.Features.AccountFeatures.Commands.DeleteUser;
using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Features.AccountFeatures.Commands.Roles.CreateRole;
using Application.Features.AccountFeatures.Commands.Roles.DeleteRole;
using Application.Features.AccountFeatures.Commands.Roles.UpdateRole;
using Application.Features.AccountFeatures.Commands.UpdateUser;
using Application.Features.AccountFeatures.Quaries.Roles.GetAllRoles;
using Application.Features.AccountFeatures.Quaries.Roles.GetRoleById;
using Application.Features.AccountFeatures.Quaries.Roles.GetUserByEmail;
using Application.Features.AccountFeatures.Quaries.Users.GetCurrentUserQuery;
using Application.Features.AccountFeatures.Quaries.Users.LoginUser;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presistence.Services;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(IMediator mediator, UserManager<AppUser> userManager,ITokenService tokenService)
        {
           _mediator = mediator;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
 
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole(DeleteRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _mediator.Send(new GetAllRolesQuary()));
        }

        [HttpGet("GetRoleById/{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        { 

            return Ok(await _mediator.Send(new GetRoleByIdQuary { Id = roleId }));
        }
        [Authorize]
        [HttpPut("UpdateUserStatus")]
        public async Task<IActionResult> UpdateUserStatus(string email)
        {

            return Ok( await _mediator.Send(new ChangeUserStatusCommand { Email = email }));
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string email)
        {

            return Ok(await _mediator.Send(new DeleteUserCommand { Email = email }));
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleCommand command)
        {

            return Ok(await _mediator.Send(command));
        }



        [HttpPost("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {

            return Ok(await _mediator.Send(new GetUserByEmailQuery { Email = email }));
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var query = new GetCurrentUserQuery(HttpContext.User);
            var currentUser = await _mediator.Send(query);
            return Ok(currentUser);
        }

    }
}
