using Application.Features.AccountFeatures.Commands.LoginUser;
using Application.Interfaces;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.AccountFeatures.Commands.UpdateUser
{
    public class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, Result<UserDto>>
    {
        private readonly IAccountService _accountService;

        public ChangeUserStatusCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Result<UserDto>> Handle(ChangeUserStatusCommand command, CancellationToken cancellationToken)
        {
           return await _accountService.ChangeUserStatusAsync(command.Email);
           
        }
    }
}
