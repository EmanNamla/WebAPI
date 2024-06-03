using Application.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachmentsByGroupId
{
    public class DeleteAttachmentsByGroupIdCommandHandler : IRequestHandler<DeleteAttachmentsByGroupIdCommand, int>
    {
        private readonly IAttachmentGroupService _attachmentGroupService;

        public DeleteAttachmentsByGroupIdCommandHandler(IAttachmentGroupService attachmentGroupService)
        {
           _attachmentGroupService = attachmentGroupService;
        }
        public async Task<int> Handle(DeleteAttachmentsByGroupIdCommand request, CancellationToken cancellationToken)
        {
            await _attachmentGroupService.DeleteAttachmentsByGroupIdAsync(request.groupId);
           return request.groupId;
        }
    }
}
