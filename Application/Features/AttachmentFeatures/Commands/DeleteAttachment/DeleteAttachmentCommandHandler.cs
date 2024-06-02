using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.DeleteAttachment
{
    public record DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand, Unit>
    {
        private readonly IAttachmentGroupService _attachmentService;

        public DeleteAttachmentCommandHandler(IAttachmentGroupService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        public async Task<Unit> Handle(DeleteAttachmentCommand command, CancellationToken cancellationToken)
        {
             await _attachmentService.DeleteAttachmentAsync(command.Id);
            return Unit.Value;
        }
    }
}
