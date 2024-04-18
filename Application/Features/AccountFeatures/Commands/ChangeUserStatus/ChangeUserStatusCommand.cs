using Domain.DTOs;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.UpdateUser
{
    public class ChangeUserStatusCommand:IRequest<Result<UserDto>>
    {
        public string Email { get; set; }
    }
}
