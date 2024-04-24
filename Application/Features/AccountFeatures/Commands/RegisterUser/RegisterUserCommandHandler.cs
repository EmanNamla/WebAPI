using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.DTOs.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,Result<UserDto>>
    {
        private readonly IAccountService _accountService;

        public RegisterUserCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Result<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RegisterUserAsync(request);
        }
    }
}
