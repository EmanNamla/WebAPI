using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.UploadAttachment
{
    public record UploadAttachmentCommand : IRequest<int>
    {
        public IFormFile File { get; set; }
    }
}
