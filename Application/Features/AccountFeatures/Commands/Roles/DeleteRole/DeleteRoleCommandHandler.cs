using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.AccountFeatures.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RoleDto>
    {
        private readonly IAccountService _accountService;

        public DeleteRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<RoleDto> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            return await _accountService.DeleteRoleAsync(command.RoleId);
        }
    }
}
