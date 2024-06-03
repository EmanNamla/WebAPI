using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.UploadAttachment
{
    public class UploadAttachmentCommand : IRequest<int>
    {
        public int GroupId { get; set; }
        public IFormFile File { get; set; }

        public UploadAttachmentCommand(int groupId, IFormFile file)
        {
            GroupId = groupId;
            File = file;
        }
    }
}
