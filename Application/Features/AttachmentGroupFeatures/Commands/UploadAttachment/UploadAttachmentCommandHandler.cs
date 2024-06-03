using Application.Interfaces.Service;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.UploadAttachment
{
    public class UploadAttachmentCommandHandler : IRequestHandler<UploadAttachmentCommand, int>
    {
        private readonly IAttachmentGroupService _attachmentGroupService;

        public UploadAttachmentCommandHandler(IAttachmentGroupService attachmentGroupService)
        {
            _attachmentGroupService = attachmentGroupService;
        }

        public async Task<int> Handle(UploadAttachmentCommand request, CancellationToken cancellationToken)
        {
           var attachment = await _attachmentGroupService.UploadAttachmentAsync(request.GroupId, request.File);
            return attachment.Id;
        }
    }
}
