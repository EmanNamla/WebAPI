using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Presistence.Repositories
{
    public class AttachmentGroupRepository : IAttachmentGroupRepository
    {
        private readonly AppIdentityDbContext _dbContext;

        public AttachmentGroupRepository(AppIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Attachment attachment)
        {
            _dbContext.Attachments.Add(attachment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Attachment attachment)
        {
            _dbContext.Attachments.Remove(attachment);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Attachment>> DeleteAttachement()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return await _dbContext.Attachments.ToListAsync();
        }

        public Task<Attachment> GetByAttachmentGroupIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Attachment> GetByIdAsync(int id)
        {
            return await _dbContext.Attachments.FindAsync(id);
        }

        public async Task UpdateAsync(Attachment attachment)
        {
            _dbContext.Attachments.Update(attachment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
