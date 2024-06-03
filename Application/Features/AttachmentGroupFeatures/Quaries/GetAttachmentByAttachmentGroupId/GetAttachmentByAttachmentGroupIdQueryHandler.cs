using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Quaries.GetAttachmentByAttachmentGroupId
{
    public class GetAttachmentByAttachmentGroupIdQueryHandler : IRequestHandler<GetAttachmentByAttachmentGroupIdQuery, IEnumerable<string>>
    {
        private readonly IAttachmentGroupRepository _attachmentGroupRepository;

        public GetAttachmentByAttachmentGroupIdQueryHandler(IAttachmentGroupRepository attachmentGroupRepository)
        {
            _attachmentGroupRepository = attachmentGroupRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetAttachmentByAttachmentGroupIdQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _attachmentGroupRepository.GetAttachmentByAttachmentGroupIdAsync(request.GroupId);
            return attachments.Select(a => a.Name);
        }
    }
}
