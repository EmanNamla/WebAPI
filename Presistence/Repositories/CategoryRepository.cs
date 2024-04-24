using Application.Interfaces.Repository;
using Domain.Entities;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppIdentityDbContext _dbContext;

        public CategoryRepository(AppIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> SearchByNameAsync(string name)
        {
            return await _dbContext.Categories.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<string> ChangeStatusAsync(int categoryId)
        {
            var category = await GetByIdAsync(categoryId);
            if (category != null)
            {
                category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
                await _dbContext.SaveChangesAsync();
                return "Status changed successfully.";
            }
            else
            {
                return "Category not found.";
            }
        }
    }
}
