using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Roles.GetAllRoles
{
    public class GetAllRolesQuary: IRequest<IEnumerable<RoleDto>>
    {

    }
}
