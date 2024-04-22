using Application.Features.AccountFeatures.Commands.AddUserToRole;
using Application.Features.AccountFeatures.Commands.ChangePassword;
using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Features.AccountFeatures.Quaries.Users.LoginUser;
using Domain.DTOs;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IAccountService
    {
        Task<Result<UserDto>> RegisterUserAsync(RegisterUserCommand command);
        Task<Result<UserDto>> LoginUserAsync(LoginUserQuery command);

        Task<Result<UserDto>> ChangePasswordAsync(ChangePasswordCommand command);

        #region Roles
        Task<RoleDto> CreateRoleAsync(string roleName);

        Task<RoleDto> UpdateRoleAsync(string roleId, string newRoleName);

        Task<RoleDto> DeleteRoleAsync(string roleId);

        Task<IEnumerable<RoleDto>> GetAllRolesAsync();

        Task<RoleDto> GetRoleByIdAsync(string roleId);
        #endregion

        Task<Result<UserDto>> ChangeUserStatusAsync(string Email);

        Task<Result<string>> DeleteUserAsync(string email);

        Task<AppUser> GetUserByEmail(string email);
        Task<UserDto> GetUserAndTokenByEmailAsync(string email);

    }
}
