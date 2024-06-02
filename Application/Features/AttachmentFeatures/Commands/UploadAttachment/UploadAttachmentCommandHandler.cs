using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.DTOs;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.UploadAttachment
{
    public class UploadAttachmentCommandHandler : IRequestHandler<UploadAttachmentCommand, int>
    {
        private readonly IAttachmentGroupService _attachmentService;

        public UploadAttachmentCommandHandler(IAttachmentGroupService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        public async Task<int> Handle(UploadAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachmentDTO = new AttachmentDto() { File = request.File, };


            return await _attachmentService.UploadAttachmentAsync(attachmentDTO);
        }
    }
}
