using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.DTOs.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result<UserDto>>
    {
        private readonly IAccountService _accountService;

        public ChangePasswordCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Result<UserDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.ChangePasswordAsync(request);
        }
    }
}
