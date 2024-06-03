
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
        Task<Attachment> UploadAttachmentAsync(int groupId, IFormFile file);

        Task<int> DeleteAttachmentByIdAsync(int attachmentId);
        Task<int> DeleteAttachmentsByGroupIdAsync(int groupId);
    }
}
