using Domain.DTOs;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> AddUser(RegisterDto userDto);
        Task<Result<AppUser>> GetUserByEmail(string email);
        Task UpdateUserAsync(AppUser user);
        Task<bool> DeleteUserAsync(string email);

        Task<Result<UserDto>> AddUserToRoleAsync(AppUser user, IdentityRole role);

        Task<AppUser> GetUserByIdAsync(string userId);

        Task<IdentityRole> GetRoleByNameAsync(string roleName);
    }
}
