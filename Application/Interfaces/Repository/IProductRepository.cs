using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);

        Task UpdateAsync(Product product);

        Task<IEnumerable<Product>> SearchByNameAsync(string name);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
