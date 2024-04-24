using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Interfaces.Service;
using Domain.DTOs;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
   

        public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            await _categoryService.DeleteCategoryAsync(command.CategoryId);
            return Unit.Value;
        }
    }
}
