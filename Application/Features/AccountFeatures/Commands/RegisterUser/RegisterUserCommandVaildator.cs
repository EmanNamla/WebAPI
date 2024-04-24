using Domain.DTOs.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountFeatures.Commands.RegisterUser
{
    public class RegisterUserCommandVaildator:AbstractValidator<RegisterDto>
    {
        public RegisterUserCommandVaildator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
                               //.MinimumLength(8)
                               //.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                               //.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                               //.Matches("[0-9]").WithMessage("Password must contain at least one numeric digit")
                               //.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        }
    }
}
