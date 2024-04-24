using Application.Interfaces.Repository;
using Domain.DTOs.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Quaries.Users.GetCurrentUserQuery
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCurrentUserQueryHandler(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var bearerToken = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var email = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

            var userDto = new UserDto(email, bearerToken);
            return Task.FromResult(userDto);
        }

    }
}
