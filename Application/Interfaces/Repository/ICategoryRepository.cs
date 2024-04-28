using Domain.Entities.Identity;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task DeleteAsync(Category category);

        Task UpdateAsync(Category category);

        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> SearchByNameAsync(string name);
    
    }
}
