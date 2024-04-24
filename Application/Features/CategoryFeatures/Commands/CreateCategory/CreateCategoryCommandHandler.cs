using Application.Interfaces.Service;
using Domain.DTOs;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var categoryDto=command.Adapt<CategoryDto>();
            return _categoryService.AddCategoryAsync(categoryDto);
        }
    }
}
