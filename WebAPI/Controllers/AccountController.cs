using Application.Features.AccountFeatures.Commands.ChangePassword;
using Application.Features.AccountFeatures.Commands.LoginUser;
using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Features.AccountFeatures.Commands.Roles.CreateRole;
using Application.Features.AccountFeatures.Commands.Roles.DeleteRole;
using Application.Features.AccountFeatures.Commands.Roles.UpdateRole;
using Application.Features.AccountFeatures.Quaries.Roles.GetAllRoles;
using Application.Features.AccountFeatures.Quaries.Roles.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
           _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
 
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
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


    }
}
