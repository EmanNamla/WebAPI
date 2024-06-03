using Domain.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Quaries.GetAttachmentByAttachmentGroupId
{
    public record GetAttachmentByAttachmentGroupIdQuery : IRequest<IEnumerable<string>>
    {
        public int GroupId { get; }

        public GetAttachmentByAttachmentGroupIdQuery(int groupId)
        {
            GroupId = groupId;
        }
    }


}
