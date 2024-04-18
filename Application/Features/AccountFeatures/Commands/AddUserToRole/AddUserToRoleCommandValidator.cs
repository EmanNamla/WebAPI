using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.AddUserToRole
{
    public class AddUserToRoleCommandValidator: AbstractValidator<AddUserToRoleCommand>
    {
        public AddUserToRoleCommandValidator()
        {
            RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("RoleName is required")
            .NotNull().WithMessage("RoleName cannot be null");

            RuleFor(x => x.UserId)
          .NotEmpty().WithMessage("UserId is required")
          .NotNull().WithMessage("UserId cannot be null");
        }
    }
}
