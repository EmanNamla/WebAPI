using Application.Interfaces.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandValidator(IProductService productService)
        {
            _productService = productService;
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(x => x.productId)
                .NotEmpty().WithMessage("Product id not emtpy")
                .NotNull().WithMessage("Product id not Null")
                .MustAsync(BeExist).WithMessage("Product id not found");
           
        }

        private async Task<bool> BeExist(int productId, CancellationToken arg2)
        {
            var category = await _productService.GetProductByIdAsync(productId);
            return category is not null;
        }
    }
}
