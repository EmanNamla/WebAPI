using Application.Features.CategoryFeatures.Commands.DeleteCategory;
using Application.Interfaces.Service;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryCommandValidator(ICategoryService categoryService)
        {
           _categoryService = categoryService;
            RuleLevelCascadeMode = CascadeMode.Stop;
            _categoryService = categoryService;
            RuleFor(x => x.CategoryDto.Name)
                .NotEmpty().WithMessage("CategoryName  not emtpy")
                .NotNull().WithMessage("CategoryName  not Null");
           RuleFor(x => x.CategoryDto.Status)
                .NotEmpty().WithMessage("CategoryStatus  not emtpy")
                .NotNull().WithMessage("CategoryStatus  not Null");
        }

        private async Task<bool> BeExist(int CategoryId, CancellationToken arg2)
        {
            var category = await _categoryService.GetCategoryByIdAsync(CategoryId);
            return category is not null;
        }

 

    }
}
