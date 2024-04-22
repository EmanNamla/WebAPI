﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.DeleteAttachment
{
    public record DeleteAttachmentCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
