using Application.Features.AccountFeatures.Commands.ChangePassword;
using Application.Features.AccountFeatures.Commands.LoginUser;
using Application.Features.AccountFeatures.Commands.RegisterUser;
using Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Result<UserDto>> RegisterUserAsync(RegisterUserCommand command);
        Task<Result<UserDto>> LoginUserAsync(LoginUserCommand command);

        Task <Result<UserDto>> ChangePasswordAsync(ChangePasswordCommand command);

        Task<RoleDto> CreateRoleAsync(string roleName);

        Task<RoleDto> UpdateRoleAsync(string roleId, string newRoleName);

        Task<RoleDto> DeleteRoleAsync(string roleId);

        Task<IEnumerable<RoleDto>> GetAllRolesAsync();

        Task<RoleDto> GetRoleByIdAsync(string roleId);
    }
}
