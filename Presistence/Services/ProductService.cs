using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            var product = productDto.Adapt<Product>();

            await _productRepository.AddAsync(product);

            return product.Adapt<ProductDto>();
        }

        public async Task<string> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }

            await _productRepository.DeleteAsync(product);
            return $"Product with ID {productId} deleted successfully.";
        }
        public async Task<IEnumerable<ProductDto>> SearchProductByNameAsync(string name)
        {
            var products = await _productRepository.SearchByNameAsync(name);
            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            return product?.Adapt<ProductDto>();
        }

        public async Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            product.Name = productDto.Name;
            product.Status = Enum.Parse<Status>(productDto.Status, true);
            product.Quantity = productDto.Quantity;
            product.CategoryId = productDto.CategoryId;
            product.AttachmentId = productDto.AttachmentId;

            await _productRepository.UpdateAsync(product);

            var returnProduct = productDto.Adapt<ProductDto>();

            return returnProduct;
        }
    }
}
