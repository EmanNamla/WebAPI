using Domain.DTOs;
using Domain.DTOs.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(20);
            RuleFor(x => x.Quantity)
             .NotEmpty().WithMessage("Quantity is required")
             .GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
