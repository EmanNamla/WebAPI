using Application.Features.AttachmentFeatures.Commands.UploadAttachment;
using Application.Features.CategoryFeatures.Commands.DeleteCategory;
using Application.Features.CategoryFeatures.Quaries.GetAllCategories;
using Application.Features.CategoryFeatures.Quaries.GetCategoryById;
using Application.Features.CategoryFeatures.Quaries.SearchCategoriesByName;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Application.Features.ProductFeatures.Commands.DeleteProduct;
using Application.Features.ProductFeatures.Commands.UpdateProduct;
using Application.Features.ProductFeatures.Quaries.GetAllProducts;
using Application.Features.ProductFeatures.Quaries.GetProductById;
using Application.Features.ProductFeatures.Quaries.SearchProductByName;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto productDto)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand(productId, productDto)));

        }
        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuary { }));
        }
        [HttpGet("GetProductById/{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuary(Id)));
        }
        [HttpGet("SearchProductsByName")]
        public async Task<IActionResult> SearchProductsByName(string productName)
        {
            return Ok(await _mediator.Send(new SearchProductByNameQuary(productName)));
        }
    }
}
