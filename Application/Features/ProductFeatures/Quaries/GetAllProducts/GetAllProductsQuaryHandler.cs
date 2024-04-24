using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.GetAllProducts
{
    public class GetAllProductsQuaryHandler : IRequestHandler<GetAllProductsQuary, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;

        public GetAllProductsQuaryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuary quary, CancellationToken cancellationToken)
        {
          return await  _productService.GetAllProductsAsync();
        }
    }
}
