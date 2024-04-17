using Domain.DTOs;
using Domain.Entities.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.Role.CreateRole
{
    public class CreateRoleCommandVaildator : AbstractValidator<RoleDto>
    {
        public CreateRoleCommandVaildator()
        {

        }
    }
}
