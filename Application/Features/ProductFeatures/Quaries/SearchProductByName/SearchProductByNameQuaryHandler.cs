using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.SearchProductByName
{
    public class SearchProductByNameQuaryHandler : IRequestHandler<SearchProductByNameQuary, IEnumerable<ProductDto>>
    {
        private readonly IProductService _productService;

        public SearchProductByNameQuaryHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IEnumerable<ProductDto>> Handle(SearchProductByNameQuary quary, CancellationToken cancellationToken)
        {
          return await  _productService.SearchProductByNameAsync(quary.name);
        }
    }
}
