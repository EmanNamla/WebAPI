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
    public record DeleteAttachmentHandler : IRequestHandler<DeleteAttachmentCommand, string>
    {
        private readonly IAttachmentService _attachmentService;

        public DeleteAttachmentHandler(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        public async Task<string> Handle(DeleteAttachmentCommand command, CancellationToken cancellationToken)
        {
            return await _attachmentService.DeleteAttachmentAsync(command.Id);
        }
    }
}
