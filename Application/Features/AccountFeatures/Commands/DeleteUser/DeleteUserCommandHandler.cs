using Application.Interfaces;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<string>>
    {
        private readonly IAccountService _accountService;

        public DeleteUserCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<Result<string>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            return await _accountService.DeleteUserAsync(command.Email);
        }
    }
}
