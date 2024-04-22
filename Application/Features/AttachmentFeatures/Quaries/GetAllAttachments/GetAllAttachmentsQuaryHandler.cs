using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Quaries.GetAllAttachments
{
    public class GetAllAttachmentsQuaryHandler : IRequestHandler<GetAllAttachmentsQuary,IEnumerable<AttachmentDto>>
    {
        private readonly IAttachmentService _attachmentService;

        public GetAllAttachmentsQuaryHandler(IAttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        public async Task<IEnumerable<AttachmentDto>> Handle(GetAllAttachmentsQuary request, CancellationToken cancellationToken)
        {
            return await _attachmentService.GetAllAttachmentsAsync();
        }
    }
}
