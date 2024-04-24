using Domain.DTOs;
using Domain.DTOs.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.AddUserToRole
{
    public class AddUserToRoleCommand : IRequest<Result<UserDto>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
