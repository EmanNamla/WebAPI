using Application.Features.AccountFeatures.Quaries.Roles.GetAllRoles;
using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Roles.GetRoleById
{
    public class GetRoleByIdQuaryHandler : IRequestHandler<GetRoleByIdQuary, RoleDto>
    {
        private readonly IAccountService _accountService;

        public GetRoleByIdQuaryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<RoleDto> Handle(GetRoleByIdQuary quary, CancellationToken cancellationToken)
        {
            var role = await _accountService.GetRoleByIdAsync(quary.Id);
            return role;
        }
    }
}
