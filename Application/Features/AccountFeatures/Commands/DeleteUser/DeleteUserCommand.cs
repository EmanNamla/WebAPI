using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest<Result<string>>
    {
        public string Email { get; set; }
    }
}
