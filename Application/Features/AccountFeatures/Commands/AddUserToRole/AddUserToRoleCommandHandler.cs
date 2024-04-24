using Application.Interfaces.Repository;
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
    public class AddUserToRoleCommandHandler : IRequestHandler<AddUserToRoleCommand, Result<UserDto>>
    {
        private readonly IAccountRepository _accountRepository;

        public AddUserToRoleCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Result<UserDto>> Handle(AddUserToRoleCommand command, CancellationToken cancellationToken)
        {
            var user = await _accountRepository.GetUserByIdAsync(command.UserId);
            var role = await _accountRepository.GetRoleByNameAsync(command.RoleName);

            if (user == null)
            {
                return Result<UserDto>.Failure("User not found.");
            }

            if (role == null)
            {
                return Result<UserDto>.Failure("Role not found.");
            }

            return await _accountRepository.AddUserToRoleAsync(user, role);
        }
    }
}
