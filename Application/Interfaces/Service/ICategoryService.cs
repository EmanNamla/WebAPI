using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto);
        Task DeleteCategoryAsync(int categoryId);
        Task<CategoryDto> UpdateCategoryAsync(int categoryId, CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<IEnumerable<CategoryDto>> SearchCategoriesByNameAsync(string name);
        Task ChangeCategoryStatusAsync(int categoryId);
    }
}
