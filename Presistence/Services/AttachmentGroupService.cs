using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.DTOs;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Services
{
    public class AttachmentGroupService:IAttachmentGroupService
    {
        private readonly IAttachmentGroupRepository _attachmentRepository;

        public AttachmentGroupService(IAttachmentGroupRepository attachmentRepository)
        {
           _attachmentRepository = attachmentRepository;
        }


        #region GetAllAttachments
        public async Task<IEnumerable<AttachmentDto>> GetAllAttachmentsAsync()
        {
            var attachments = await _attachmentRepository.GetAllAsync();

            var attachmentDtos = attachments.Select(attachment => new AttachmentDto
            {
                Id = attachment.Id,
                Name = attachment.Name,
                ContentType = attachment.ContentType,
                Extension = attachment.Extension
            });

            return attachmentDtos;
        }
        #endregion


        #region GetAttachmentById
        public async Task<AttachmentDto> GetAttachmentByIdAsync(int attachmentId)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
            if (attachment == null)
            {
                throw new InvalidOperationException($"Attachment with ID {attachmentId} not found");
            }

            return new AttachmentDto
            {
                Id = attachment.Id,
                Name = attachment.Name,
                ContentType = attachment.ContentType,
                Extension = attachment.Extension
            };
        } 
        #endregion

        #region DeleteAttachment
        public async Task DeleteAttachmentAsync(int attachmentId)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
          
            DeleteFile(attachment.Name);
            await _attachmentRepository.DeleteAsync(attachment);
           
        } 
        #endregion

        #region UpdateAttachment
        public async Task<int> UpdateAttachmentAsync(int attachmentId, AttachmentDto attachmentDto)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(attachmentId);
            if (attachment == null)
            {
                throw new InvalidOperationException($"Attachment with ID {attachmentId} not found");
            }


            DeleteFile(attachment.Name);


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachmentDto.File.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await attachmentDto.File.CopyToAsync(stream);
            }

            attachment.Name = fileName;
            attachment.ContentType = attachmentDto.File.ContentType;
            attachment.Extension = Path.GetExtension(attachmentDto.File.FileName);

            await _attachmentRepository.UpdateAsync(attachment);

            return attachmentId;
        } 
        #endregion


        #region UploadAttachment
        public async Task<int> UploadAttachmentAsync(AttachmentDto attachmentDTO)
        {
            if (attachmentDTO.File == null || attachmentDTO.File.Length == 0)
            {
                throw new InvalidOperationException("No file uploaded");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachmentDTO.File.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await attachmentDTO.File.CopyToAsync(stream);

            var attachment = new Domain.Entities.Attachment
            {
                Name = fileName,
                ContentType = attachmentDTO.File.ContentType,
                Extension = Path.GetExtension(attachmentDTO.File.FileName)
            };

            await _attachmentRepository.AddAsync(attachment);

            return attachment.Id;
        }
        #endregion

        #region staticMethosDeleteFileInwwwroot
        public static void DeleteFile(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion


        public Task<AttachmentDto> GetAttachmentByGroupId(int attachmentGroupId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAttachmentByGroupIdAsync(int groupId)
        {
            throw new NotImplementedException();
        }


    }
}
