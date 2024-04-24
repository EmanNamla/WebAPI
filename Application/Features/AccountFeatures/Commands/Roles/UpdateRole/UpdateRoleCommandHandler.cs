using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Interfaces.Service;
using Domain.DTOs.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.Roles.UpdateRole
{
    public class UpdateRoleCommandHandler:IRequestHandler<UpdateRoleCommand, RoleDto>
    {
        private readonly IAccountService _accountService;

        public UpdateRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RoleDto> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            return await _accountService.UpdateRoleAsync(command.RoleId, command.RoleName);
        }
    }
}
