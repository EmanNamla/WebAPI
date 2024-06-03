using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachment
{
    public record DeleteAttachmentCommand(int GroupId, int AttachmentId) : IRequest;
}
