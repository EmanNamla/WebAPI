using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.GetAllCategories
{
    public class GetAllCategoriesQuaryHandler:IRequestHandler<GetAllCategoriesQuary,IEnumerable<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQuaryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuary request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategoriesAsync();
        }
    }
}
