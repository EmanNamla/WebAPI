
using Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachment;
using Application.Features.AttachmentGroupFeatures.Commands.UploadAttachment;
using Application.Features.AttachmentGroupFeatures.Quaries.GetAttachmentByAttachmentGroupId;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttachmentGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{groupId}/attachments/upload")]
        public async Task<ActionResult> UploadAttachment(int groupId, IFormFile file)
        {
            return Ok(await _mediator.Send(new UploadAttachmentCommand(groupId, file)));

        }


        [HttpDelete("{groupId}/attachments/{attachmentId}")]
        public async Task<ActionResult> DeleteAttachment(int groupId, int attachmentId)
        {
            return Ok(await _mediator.Send(new DeleteAttachmentCommand(groupId, attachmentId)));

        }

        [HttpGet("{groupId}/attachments")]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Attachment>>> GetAttachmentsByGroupId(int groupId)
        {
            return Ok(await _mediator.Send(new GetAttachmentByAttachmentGroupIdQuery(groupId)));
        }



    }
}
