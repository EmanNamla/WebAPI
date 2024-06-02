using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.AttachmentFeatures.Quaries.GetAttachmentById
{
    public class GetAttachmentByIdQuaryHandler : IRequestHandler<GetAttachmentByIdQuary, AttachmentDto>
    {
        private readonly IAttachmentGroupService _attachmentService;

        public GetAttachmentByIdQuaryHandler(IAttachmentGroupService attachmentService)
        {
            _attachmentService = attachmentService;
        }
        public async Task<AttachmentDto> Handle(GetAttachmentByIdQuary quary, CancellationToken cancellationToken)
        {
            return await _attachmentService.GetAttachmentByIdAsync(quary.Id);
             
        }
    }
}
