using Domain.DTOs;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Quaries.GetAllAttachments
{
    public record GetAllAttachmentsQuary: IRequest<IEnumerable<AttachmentDto>>
    {

    }
}
