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
        Task<Attachment> GetAttachmentByAttachmentIdAsync(int id);
        Task<List<Attachment>> GetAttachmentByAttachmentGroupIdAsync(int groupId);
        Task<AttachmentGroup> GetAttachmentGroupByGroupId(int id);

        Task SaveAttachmentAsync(int groupId, Attachment attachment);
        Task DeleteAttachmentByAttachmentIdAsync(int attachmentId);
        Task DeleteAttachmentsByGroupIdAsync(int groupId);
    }
}
