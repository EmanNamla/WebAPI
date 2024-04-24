using Domain.DTOs.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Roles.GetRoleById
{
    public class GetRoleByIdQuary:IRequest<RoleDto>
    {
        public string Id { get; set; }
    }
}
