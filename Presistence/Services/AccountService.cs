using Application.Features.AccountFeatures.Commands.AddUserToRole;
using Application.Features.AccountFeatures.Commands.ChangePassword;
using Application.Features.AccountFeatures.Commands.LoginUser;
using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Interfaces;
using Azure.Core;
using Domain.DTOs;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presistence.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(IAccountRepository accountRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }


        #region Register
        public async Task<Result<UserDto>> RegisterUserAsync(RegisterUserCommand command)
        {
            var user = command.Adapt<RegisterDto>();

            var registrationResult = await _accountRepository.AddUser(user);
            if (!registrationResult.Succeeded)
            {
                return Result<UserDto>.Failure(registrationResult.Errors.FirstOrDefault()?.Description);
            }
            var AppUser = registrationResult.Adapt<AppUser>();
            return Result<UserDto>.Success(new UserDto
            {
                Email = command.Email,
                Token = await _tokenService.CreateTokenAsync(AppUser, _userManager)
            });
        } 
        #endregion

        #region Login
        public async Task<Result<UserDto>> LoginUserAsync(LoginUserCommand command)
        {
            var userDto = command.Adapt<UserDto>();

            var getUserResult = await _accountRepository.GetUserByEmail(userDto.Email);

            if (!getUserResult.IsSuccess)
            {
                return Result<UserDto>.Failure("User not found.");
            }


            var result = await _signInManager.PasswordSignInAsync(getUserResult.Data.UserName, command.Password, true, false);
            if (!result.Succeeded)
            {
                return Result<UserDto>.Failure("Invalid Email or Password");
            }
            var appUser = await _userManager.FindByEmailAsync(userDto.Email);
            return Result<UserDto>.Success(new UserDto
            {
                Email = command.Email,
                Token = await _tokenService.CreateTokenAsync(appUser, _userManager)
            });
        } 
        #endregion

        #region ChangePassword
        public async Task<Result<UserDto>> ChangePasswordAsync(ChangePasswordCommand command)
        {
            var getUserResult = await _accountRepository.GetUserByEmail(command.Email);
            if (!getUserResult.IsSuccess)
            {

                return Result<UserDto>.Failure("User not found");
            }

            var currentUser = getUserResult.Data;

            var passwordValid = await _userManager.CheckPasswordAsync(currentUser, command.CurrentPassword);
            if (!passwordValid)
            {
                return Result<UserDto>.Failure("Current password is incorrect");
            }
            if (string.Compare(command.NewPassword, command.ConfirmNewPassword) != 0)
            {
                return Result<UserDto>.Failure("The New Password, and Confirm new Password does not match");
            }
            var result = await _userManager.ChangePasswordAsync(currentUser, command.CurrentPassword, command.NewPassword);

            if (!result.Succeeded)
            {
                return Result<UserDto>.Failure(result.Errors.FirstOrDefault()?.Description);
            }
            var retuenUser = new UserDto
            {
                Email = currentUser.Email,
            };

            return Result<UserDto>.Success(retuenUser, "Password changed successfully");
        } 
        #endregion

        #region Roles
        public async Task<RoleDto> CreateRoleAsync(string roleName)
        {
            var role = new IdentityRole { Name = roleName };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMessage);
            }

            var returnRole = role.Adapt<RoleDto>();
            return returnRole;
        }

        public async Task<RoleDto> UpdateRoleAsync(string roleId, string newRoleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new Exception($"Role with ID '{roleId}' not found");
            }

            role.Name = newRoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMessage);
            }
            var returnRole = role.Adapt<RoleDto>();
            return returnRole;
        }

        public async Task<RoleDto> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new Exception($"Role with ID '{roleId}' not found.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception(errorMessage);
            }
            var returnRole = role.Adapt<RoleDto>();
            return returnRole;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var returnRoles = roles.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name

            });

            return returnRoles;
        }
        public async Task<RoleDto> GetRoleByIdAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new Exception($"Role with ID '{roleId}' not found.");
            }
            var returnRoles = role.Adapt<RoleDto>();
            return returnRoles;
        }
        #endregion

        #region ChangeUserStatus
        public async Task<Result<UserDto>> ChangeUserStatusAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);


            if (user != null)
            {
                user.Status = user.Status == Status.Active ? Status.Inactive : Status.Active;

                await _accountRepository.UpdateUserAsync(user);
                var userDto = user.Adapt<UserDto>();
                return Result<UserDto>.Success(new UserDto
                {
                    Email = user.Email,
                    Token = await _tokenService.CreateTokenAsync(user, _userManager)
                });
            }
            else
            {
                return Result<UserDto>.Failure("User not found.");
            }
        }


        #endregion

        #region  DeleteUser
        public async Task<Result<string>> DeleteUserAsync(string email)
        {
            var isDeleted = await _accountRepository.DeleteUserAsync(email);
            if (isDeleted)
            {
                return Result<string>.Success(null, "User deleted is successful");
            }
            else
            {
                return Result<string>.Failure("User not found or deleted failed");
            }
        }



        #endregion


        public async Task<UserDto> GetUserAndTokenByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _tokenService.CreateTokenAsync(user, _userManager);

            return new UserDto { Email = user.Email, Token = token };
        }
        public async Task<AppUser> GetUserByEmail(string email)
        {
            var user = await _accountRepository.GetUserByEmail(email);
            var userDto = user.Adapt<AppUser>();
            return user != null ? new AppUser { Email = userDto.Email, FirstName = userDto.FirstName, LastName = userDto.LastName } : null;
        }

    }
}
