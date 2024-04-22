using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Users.LoginUser
{
    public class LoginUserQuery : IRequest<Result<UserDto>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
