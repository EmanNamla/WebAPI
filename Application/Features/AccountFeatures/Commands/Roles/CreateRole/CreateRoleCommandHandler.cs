using Application.Features.AccountFeatures.Commands.RegisterUser;
using Application.Features.AccountFeatures.Commands.Role.UpdateRole;
using Application.Interfaces;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.Roles.CreateRole
{
    public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommand, RoleDto>
    {
        private readonly IAccountService _accountService;
        public CreateRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RoleDto> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            return await _accountService.CreateRoleAsync(command.RoleName);
        }
    }
}
