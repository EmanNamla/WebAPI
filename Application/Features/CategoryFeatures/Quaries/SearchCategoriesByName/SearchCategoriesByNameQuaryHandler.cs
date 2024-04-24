using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.SearchCategoriesByName
{
    public class SearchCategoriesByNameQuaryHandler : IRequestHandler<SearchCategoriesByNameQuary, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public SearchCategoriesByNameQuaryHandler(ICategoryService categoryService)
        {
           _categoryService = categoryService;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(SearchCategoriesByNameQuary request, CancellationToken cancellationToken)
        {
          return await _categoryService.SearchCategoriesByNameAsync(request.CategoryName);
        }
    }
}
