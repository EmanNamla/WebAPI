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
    public class UpdateRoleCommand:IRequest<RoleDto>
    {
        public string RoleId { get; set; }  
        public string RoleName { get; set; }
    }
}
