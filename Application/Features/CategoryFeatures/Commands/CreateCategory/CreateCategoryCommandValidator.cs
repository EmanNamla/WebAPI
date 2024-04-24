using Application.Interfaces.Service;
using Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull()
                .WithMessage("Name is required")
                .MaximumLength(20);//.MustAsync(BeUnique);
            RuleFor(x => x.Status).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
           
        }

        //private async Task<bool> BeUnique(string name, CancellationToken arg2)
        //{
        //    //_categoryService.GetCategoryByIdAsync()
        //}
    }
}
