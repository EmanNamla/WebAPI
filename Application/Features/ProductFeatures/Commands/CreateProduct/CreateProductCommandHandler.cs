using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //var productDto = new ProductDto
            //{
            //    Name = command.Name,
            //    Status = (Status)(byte)command.Status, // Convert enum value to byte
            //    Quantity = command.Quantity,
            //    CategoryId = command.CategoryId,
            //    AttachmentId = command.AttachmentId
            //};
            var productDto = command.Adapt<ProductDto>();
            return await _productService.AddProductAsync(productDto);
        }
    }
}
