using Application.Interfaces.Service;
using Domain.DTOs;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
         

            return await _categoryService.UpdateCategoryAsync(command.CategoryId, command.CategoryDto );
        }
    }
}
