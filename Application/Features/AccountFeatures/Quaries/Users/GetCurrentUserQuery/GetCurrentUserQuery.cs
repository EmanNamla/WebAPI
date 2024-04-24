using Domain.DTOs.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Users.GetCurrentUserQuery
{
    public record GetCurrentUserQuery(ClaimsPrincipal User) :IRequest<UserDto>;
}
