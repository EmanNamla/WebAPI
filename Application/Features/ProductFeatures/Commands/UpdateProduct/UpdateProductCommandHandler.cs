using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            return await _productService.UpdateProductAsync(command.ProductId, command.ProductDto);
        }
    }
}
