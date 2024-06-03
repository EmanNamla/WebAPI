using Application.Interfaces.Service;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentFeatures.Commands.DeleteAttachment
{
    //public class DeleteAttachmentCommandValidator:AbstractValidator<DeleteAttachmentCommand>
    //{
    //    private readonly IAttachmentGroupService _attachmentService;

    //    public DeleteAttachmentCommandValidator(IAttachmentGroupService attachmentService)
    //    {
    //        _attachmentService = attachmentService;
    //        RuleLevelCascadeMode = CascadeMode.Stop;

    //        RuleFor(x => x.Id)
    //            .NotEmpty().WithMessage("Category id not emtpy")
    //            .NotNull().WithMessage("Category id not Null")
    //            .MustAsync(BeExist).WithMessage("Category id not found");
    //    }

    //    private async Task<bool> BeExist(int id, CancellationToken arg2)
    //    {
    //        var attachment = await _attachmentService.GetAttachmentByIdAsync(id);
    //        return attachment is not null;
    //    }
    //}
}
