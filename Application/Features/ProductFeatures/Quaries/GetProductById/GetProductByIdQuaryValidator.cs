using Application.Interfaces.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.GetProductById
{
    public class GetProductByIdQuaryValidator:AbstractValidator<GetProductByIdQuary>
    {
        private readonly IProductService _productService;

        public GetProductByIdQuaryValidator(IProductService productService)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
       
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("product id not emtpy")
                .NotNull().WithMessage("product id not Null")
                .MustAsync(BeExist).WithMessage("product id not found");
            _productService = productService;
        }

        private async Task<bool> BeExist(int ProductId, CancellationToken arg2)
        {
            var product = await _productService.GetProductByIdAsync(ProductId);
            return product is not null;
        }
    }
}
