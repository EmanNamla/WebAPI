
using Application.Features.CategoryFeatures.Commands.ChangeStatus;
using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Features.CategoryFeatures.Commands.DeleteCategory;
using Application.Features.CategoryFeatures.Commands.UpdateCategory;
using Application.Features.CategoryFeatures.Quaries.GetAllCategories;
using Application.Features.CategoryFeatures.Quaries.GetCategoryById;
using Application.Features.CategoryFeatures.Quaries.SearchCategoriesByName;
using Application.Features.ProductFeatures.Commands.CreateProduct;
using Application.Features.ProductFeatures.Commands.UpdateProduct;
using Domain.DTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("ChangeCategoryStatus/{id}")]
        public async Task<IActionResult> ChangeCategoryStatus(int id)
        {
            return Ok(await _mediator.Send(new ChangeCategoryStatusCommand { CategoryId = id }));
        }
        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command )
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateCategory/{categoryId}")]
        public async Task<IActionResult> UpdateProduct(int categoryId,CategoryDto categoryDto)
        {
            return Ok(await _mediator.Send(new UpdateCategoryCommand(categoryId, categoryDto)));

        }
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllCategoriesQuary { }));
        }
        [HttpGet("GetCategoryById/{Id}")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            return Ok(await _mediator.Send(new GetCategoryByIdQuary (Id)));
        }
        [HttpGet("SearchCategoriesByName")]
        public async Task<IActionResult> SearchCategoriesByName(string CategoryName)
        {
            return Ok(await _mediator.Send(new SearchCategoriesByNameQuary(CategoryName)));
        }
    }
}
