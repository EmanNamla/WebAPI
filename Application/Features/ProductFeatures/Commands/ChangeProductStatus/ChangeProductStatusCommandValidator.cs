using Application.Interfaces.Service;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.ChangeProductStatus
{
    public class ChangeProductStatusCommandValidator:AbstractValidator<ChangeProductStatusCommand>
    {
        private readonly IProductService _productService;

        public ChangeProductStatusCommandValidator(IProductService productService)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.productId)
                .NotEmpty().WithMessage("Product id not emtpy")
                .NotNull().WithMessage("Product id not Null")
                .MustAsync(BeExist).WithMessage("Product id not found");
            _productService = productService;
        }

        private async Task<bool> BeExist(int productId, CancellationToken arg2)
        {

            var product = await _productService.GetProductByIdAsync(productId);
            return product is not null;
        }
    }
}
