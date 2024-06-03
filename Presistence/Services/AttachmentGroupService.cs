using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Domain.Entities;
using System.Text;
using System.Threading.Tasks;
using Attachment = Domain.Entities.Attachment;

namespace Presistence.Services
{
    public class AttachmentGroupService:IAttachmentGroupService
    {
        private readonly IAttachmentGroupRepository _attachmentGroupRepository;
        private readonly IWebHostEnvironment _environment;

        public AttachmentGroupService(IAttachmentGroupRepository attachmentGroupRepository, IWebHostEnvironment environment)
        {
            _attachmentGroupRepository = attachmentGroupRepository;
            _environment = environment;
        }

        public async Task<Attachment> UploadAttachmentAsync(int groupId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty", nameof(file));
            }

            var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var attachment = new Attachment
            {
                Name = fileName,
                ContentType = file.ContentType,
                Extension = fileExtension,
                AttachmentGroupId = groupId
            };

            await _attachmentGroupRepository.SaveAttachmentAsync(groupId, attachment);

            return attachment;
        }

        public async Task<int> DeleteAttachmentByIdAsync(int attachmentId)
        {
            var attachment = await _attachmentGroupRepository.GetAttachmentByAttachmentIdAsync(attachmentId);
            if (attachment == null)
            {
                throw new KeyNotFoundException("Attachment not found");
            }

            var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploadsFolderPath, attachment.Name);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            await _attachmentGroupRepository.DeleteAttachmentByAttachmentIdAsync(attachmentId);
            return attachmentId;
        }

        public async Task<int> DeleteAttachmentsByGroupIdAsync(int groupId)
        {
            var attachmentGroup = await _attachmentGroupRepository.GetAttachmentGroupByGroupId(groupId);

            if (attachmentGroup == null)
            {
                throw new KeyNotFoundException("AttachmentGroup not found");
            }

            foreach (var attachment in attachmentGroup.Attachments)
            {
                var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploadsFolderPath, attachment.Name);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            await _attachmentGroupRepository.DeleteAttachmentsByGroupIdAsync(groupId);
            return groupId;
        }



      
    }
}
