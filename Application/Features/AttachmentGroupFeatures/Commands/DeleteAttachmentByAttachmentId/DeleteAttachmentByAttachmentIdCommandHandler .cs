using Application.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachmentByAttachmentId
{
    public class DeleteAttachmentByAttachmentIdCommandHandler : IRequestHandler<DeleteAttachmentByAttachmentIdCommand, int>
    {
        private readonly IAttachmentGroupService _attachmentGroupService;

        public DeleteAttachmentByAttachmentIdCommandHandler(IAttachmentGroupService attachmentGroupService)
        {

            _attachmentGroupService = attachmentGroupService;
        }

        public async Task<int> Handle(DeleteAttachmentByAttachmentIdCommand request, CancellationToken cancellationToken)
        {
            await _attachmentGroupService.DeleteAttachmentByIdAsync(request.attachmentId);
            return request.attachmentId;
        }
    }
}
