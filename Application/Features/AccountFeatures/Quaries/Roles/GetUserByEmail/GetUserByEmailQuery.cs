using Domain.DTOs;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Roles.GetUserByEmail
{
    public class GetUserByEmailQuery:IRequest<AppUser>
    {
        public string Email { get; set; }
    }
}
