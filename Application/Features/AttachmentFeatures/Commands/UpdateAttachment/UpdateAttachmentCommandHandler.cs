using Application.Interfaces.Service;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.UpdateAttachment
{
    //public class UpdateAttachmentCommandHandler : IRequestHandler<UpdateAttachmentCommand, int>
    //{
    //    private readonly IAttachmentGroupService _attachmentService;

    //    public UpdateAttachmentCommandHandler(IAttachmentGroupService attachmentService)
    //    {
    //        _attachmentService = attachmentService;
    //    }
    //    //public async Task<int> Handle(UpdateAttachmentCommand request, CancellationToken cancellationToken)
    //    //{
    //    //    var attachmentDTO = new AttachmentDto() { File = request.File };


    //    //    return await _attachmentService.UpdateAttachmentAsync(request.Id, attachmentDTO);
    //    //}
    //}
}
