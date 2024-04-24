using Application.Interfaces.Service;
using Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.SearchCategoriesByName
{
    public class SearchCategoriesByNameQuaryValidator:AbstractValidator<IEnumerable<CategoryDto>>
    {
        public SearchCategoriesByNameQuaryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Select(category=>category.Name))
                .NotEmpty().WithMessage("Category Name not emtpy")
                .NotNull().WithMessage("Category Name not Null");
              
        }
    }
}
