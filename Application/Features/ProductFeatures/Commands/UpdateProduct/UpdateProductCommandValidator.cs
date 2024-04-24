using Application.Interfaces.Service;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandValidator(IProductService productService)
        {
            _productService = productService;
            RuleLevelCascadeMode = CascadeMode.Stop;
 
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product id not emtpy")
                .NotNull().WithMessage("Product id not Null")
                .MustAsync(BeExist).WithMessage("product id not found");

            RuleFor(x => x.ProductDto.Name)
               .NotEmpty().WithMessage("ProductName id not emtpy")
               .NotNull().WithMessage("ProductName id not Null");


            RuleFor(x => x.ProductDto.AttachmentId)
               .NotEmpty().WithMessage("Attachment id not emtpy")
               .NotNull().WithMessage("Attachment id not Null");

        }

        private async Task<bool> BeExist(int ProductId, CancellationToken arg2)
        {

            var product = await _productService.GetProductByIdAsync(ProductId);
            return product is not null;
        }
    }
  
}
