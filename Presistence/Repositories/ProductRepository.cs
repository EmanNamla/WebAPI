using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppIdentityDbContext _dbContext;

        public ProductRepository(AppIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _dbContext.Products.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
