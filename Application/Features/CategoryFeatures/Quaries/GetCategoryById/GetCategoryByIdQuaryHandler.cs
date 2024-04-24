using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.GetCategoryById
{
    public class GetCategoryByIdQuaryHandler : IRequestHandler<GetCategoryByIdQuary, CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdQuaryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdQuary quary, CancellationToken cancellationToken)
        {
           return await  _categoryService.GetCategoryByIdAsync(quary.CategoryId);
        }
    }
}
