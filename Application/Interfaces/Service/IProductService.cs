using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IProductService
    {
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto);
        Task<string> DeleteProductAsync(int productId);
        Task<IEnumerable<ProductDto>> SearchProductByNameAsync(string name);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    }
}
