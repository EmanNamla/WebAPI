using Application.Interfaces.Service;
using Domain.DTOs.Identity;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Roles.GetAllRoles
{
    public class GetAllRolesQuaryHandler : IRequestHandler<GetAllRolesQuary, IEnumerable<RoleDto>>
    {
        private readonly IAccountService _accountService;

        public GetAllRolesQuaryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuary request, CancellationToken cancellationToken)
        {
            var roles = await _accountService.GetAllRolesAsync();
            return roles;
        }
    }
}
