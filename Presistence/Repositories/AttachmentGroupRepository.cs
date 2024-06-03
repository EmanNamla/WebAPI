using Application.Interfaces.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private async Task<AttachmentGroup> GetAttachmentGroupWithAttachmentsAsync(int groupId)
        {
            var attachmentGroup = await _dbContext.AttachmentGroups
                .Include(ag => ag.Attachments)
                .FirstOrDefaultAsync(ag => ag.Id == groupId);

            if (attachmentGroup == null)
            {
                attachmentGroup = new AttachmentGroup(); 
               
            }

            return attachmentGroup;
        }

        public async Task<List<Attachment>> GetAttachmentByAttachmentGroupIdAsync(int groupId)
        {
            var attachmentGroup = await _dbContext.AttachmentGroups
                .Include(ag => ag.Attachments)
                .FirstOrDefaultAsync(ag => ag.Id == groupId);

            if (attachmentGroup == null)
            {
                throw new KeyNotFoundException($"AttachmentGroup with ID {groupId} not found");
            }

            return attachmentGroup.Attachments;
        }



        public async Task SaveAttachmentAsync(int groupId, Attachment attachment)
        {
            var attachmentGroup = await GetAttachmentGroupWithAttachmentsAsync(groupId);

            if (attachmentGroup == null)
            {
                throw new KeyNotFoundException("AttachmentGroup not found");
            }

            if (attachment.Id == 0)
            {
                attachmentGroup.Attachments.Add(attachment);
            }
            else
            {
                var existingAttachment = attachmentGroup.Attachments.FirstOrDefault(a => a.Id == attachment.Id);
                if (existingAttachment != null)
                {
                    existingAttachment.Name = attachment.Name;
                    existingAttachment.ContentType = attachment.ContentType;
                    existingAttachment.Extension = attachment.Extension;

                }
                else
                {
                    attachmentGroup.Attachments.Add(attachment);
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAttachmentAsync(int groupId, int attachmentId)
        {
            var attachmentGroup = await GetAttachmentGroupWithAttachmentsAsync(groupId);

            if (attachmentGroup == null)
            {
                throw new KeyNotFoundException("AttachmentGroup not found");
            }

            var attachment = attachmentGroup.Attachments.FirstOrDefault(a => a.Id == attachmentId);
            if (attachment != null)
            {
                attachmentGroup.Attachments.Remove(attachment);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<AttachmentGroup> GetAttachmentGroupByGroupId(int id)
        {
            var attachmentGroup = await _dbContext.AttachmentGroups
            .Include(ag => ag.Attachments)
                .FirstOrDefaultAsync(ag => ag.Id == id);
            return attachmentGroup;
        }




























        ////////////////////////


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
