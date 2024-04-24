using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.GetProductById
{
    public class GetProductByIdQuaryHandler : IRequestHandler<GetProductByIdQuary, ProductDto>
    {
        private readonly IProductService _productService;

        public GetProductByIdQuaryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuary quary, CancellationToken cancellationToken)
        {
          return await  _productService.GetProductByIdAsync(quary.id);
        }
    }
}
