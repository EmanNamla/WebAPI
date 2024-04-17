using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommand:IRequest<RoleDto>
    {
        public string RoleId { get; set; }
    }
}
