using Domain.DTOs;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> AddUser(RegisterDto userDto);
        Task<Result<AppUser>> GetUserByEmail(string email);
    }
}
