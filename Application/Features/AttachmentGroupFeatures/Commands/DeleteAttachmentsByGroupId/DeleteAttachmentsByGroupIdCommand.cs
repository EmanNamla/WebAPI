using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachmentsByGroupId
{
    public record DeleteAttachmentsByGroupIdCommand(int  groupId):IRequest<int>
    {
    }
}
