using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.UpdateAttachment
{
    public record UpdateAttachmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
