using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Quaries.GetAttachmentById
{
    public record GetAttachmentByIdQuary:IRequest<AttachmentDto>
    {
        public int Id { get; set; }
    }
}
