
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IAttachmentService
    {
        Task<int> UploadAttachmentAsync(AttachmentDto attachmentDto);
        Task<int> UpdateAttachmentAsync(int attachmentId, AttachmentDto attachmentDto);
        Task DeleteAttachmentAsync(int attachmentId);
        Task<AttachmentDto> GetAttachmentByIdAsync(int attachmentId);
        Task<IEnumerable<AttachmentDto>> GetAllAttachmentsAsync();

    }
}
