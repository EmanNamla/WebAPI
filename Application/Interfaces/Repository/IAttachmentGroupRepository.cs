using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Interfaces.Repository
{
    public interface IAttachmentGroupRepository
    {
        Task AddAsync(Attachment attachment);
        Task DeleteAsync(Attachment attachment);

        Task UpdateAsync(Attachment attachment);

        Task<Attachment> GetByIdAsync(int id);
        Task<IEnumerable<Attachment>> GetAllAsync();

        Task<Attachment> GetByAttachmentGroupIdAsync(int id);
        Task<IEnumerable<Attachment>> DeleteAttachement();

        /// <summary>
        /// /////////
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>

        Task<List<Attachment>> GetAttachmentByAttachmentGroupIdAsync(int groupId);
        Task<AttachmentGroup> GetAttachmentGroupByGroupId(int id);

        Task SaveAttachmentAsync(int groupId, Attachment attachment);
        Task DeleteAttachmentAsync(int groupId, int attachmentId);

    }
}
