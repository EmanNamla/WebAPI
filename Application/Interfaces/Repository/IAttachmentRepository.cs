using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IAttachmentRepository
    {
     
            Task AddAsync(Attachment attachment);
            Task DeleteAsync(Attachment attachment);

            Task UpdateAsync(Attachment attachment);

            Task<Attachment> GetByIdAsync(int id);
            Task<IEnumerable<Attachment>> GetAllAsync();

        
    }
}
