using Application.Features.CategoryFeatures.Commands.CreateCategory;
using Application.Interfaces.Service;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandValidator(ICategoryService categoryService)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            _categoryService = categoryService;
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category id not emtpy")
                .NotNull().WithMessage("Category id not Null")
                .MustAsync(BeExist).WithMessage("Category id not found");

                
        }

        private async Task<bool> BeExist(int CategoryId, CancellationToken arg2)
        {
            var category = await _categoryService.GetCategoryByIdAsync(CategoryId);
            return category is not null;
        }
    }
}
