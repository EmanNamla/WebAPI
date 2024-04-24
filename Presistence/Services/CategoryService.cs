using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using MediatR;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();

            await _categoryRepository.AddAsync(category);

            var Returncategory = category.Adapt<CategoryDto>();
            return Returncategory;
        }

        public async Task<string> ChangeCategoryStatusAsync(int categoryId)
        {
          return   await _categoryRepository.ChangeStatusAsync(categoryId);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var Category =await _categoryRepository.GetByIdAsync(categoryId);
            var CategoryDeleted = Category.Adapt<Category>();
             await _categoryRepository.DeleteAsync(Category);
        }

      

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Adapt<IEnumerable<CategoryDto>>();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return category?.Adapt<CategoryDto>();
        }

        public async Task<IEnumerable<CategoryDto>> SearchCategoriesByNameAsync(string name)
        {
            var categories = await _categoryRepository.SearchByNameAsync(name);
            return categories.Adapt<IEnumerable<CategoryDto>>();
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int categoryId, CategoryDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            category.Name = categoryDto.Name;
            category.Status = Enum.Parse<Status>(categoryDto.Status, true);

            await _categoryRepository.UpdateAsync(category);


            var returnCategory = categoryDto.Adapt<CategoryDto>();

            return returnCategory;


        }
    }
}
