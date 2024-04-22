using Application.Interfaces.Service;
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
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, AppUser>
    {
        private readonly IAccountService _accountService;

        public GetUserByEmailQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task< AppUser> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            return await _accountService.GetUserByEmail(query.Email);
        }
    }
}
