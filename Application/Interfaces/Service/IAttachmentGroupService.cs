
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IAttachmentGroupService
    {
        Task<int> UploadAttachmentAsync(AttachmentDto attachmentDto);
        Task<int> UpdateAttachmentAsync(int attachmentId, AttachmentDto attachmentDto);
        Task DeleteAttachmentAsync(int attachmentId);
        Task<AttachmentDto> GetAttachmentByIdAsync(int attachmentId);
        Task<IEnumerable<AttachmentDto>> GetAllAttachmentsAsync();

        Task<AttachmentDto> GetAttachmentByGroupId(int attachmentGroupId);

        Task DeleteAttachmentByGroupIdAsync(int groupId);

        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<Attachment> UploadAttachmentAsync(int groupId, IFormFile file);
        Task DeleteAttachmentAsync(int groupId, int attachmentId);
        Task<Attachment> GetAttachmentByAttachmentGroupIdAsync(int groupId, int attachmentId);
    }
}
