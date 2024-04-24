using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.SearchCategoriesByName
{
    public record SearchCategoriesByNameQuary(string CategoryName):IRequest<IEnumerable<CategoryDto>>;
    
}
