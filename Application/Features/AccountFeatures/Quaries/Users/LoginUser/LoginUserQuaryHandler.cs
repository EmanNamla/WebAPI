using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Users.LoginUser
{
    public class LoginUserQuaryHandler : IRequestHandler<LoginUserQuery, Result<UserDto>>
    {
        private readonly IAccountService _accountService;

        public LoginUserQuaryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Result<UserDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {

            return await _accountService.LoginUserAsync(request);
        }
    }
}
