using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.SearchProductByName
{
    public class SearchProductByNameQuaryValidator:AbstractValidator<SearchProductByNameQuary>
    {
        public SearchProductByNameQuaryValidator()
        {
            RuleFor(x => x.name)
               .NotEmpty().WithMessage("ProductName id not emtpy")
               .NotNull().WithMessage("ProductName id not Null");
        }
    }
}
