//    using Application.Features.AttachmentFeatures.Commands.DeleteAttachment;
//using Application.Features.AttachmentFeatures.Commands.UpdateAttachment;
//using Application.Features.AttachmentFeatures.Commands.UploadAttachment;
//using Application.Features.AttachmentFeatures.Quaries.GetAllAttachments;
//using Application.Features.AttachmentFeatures.Quaries.GetAttachmentById;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AttachmentController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public AttachmentController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }
//        [HttpPost("UploadAttachment")]
//        public async Task<IActionResult> UploadAttachment([FromForm] IFormFile file)
//        {
//            return Ok(await _mediator.Send(new UploadAttachmentCommand { File = file }));
//        }
//        [HttpPut("UpdateAttachment/{id}")]
//        public async Task<IActionResult> UpdateAttachment(int id, [FromForm] UpdateAttachmentCommand command)
//        {
//            return Ok(await _mediator.Send(new UpdateAttachmentCommand  {  Id = id, File = command.File}));
//        }
//        [HttpPost("DeleteAttachment/{id}")]
//        public async Task<IActionResult> DeleteAttachment(int id)
//        {
//            return Ok(await _mediator.Send(new DeleteAttachmentCommand { Id = id }));
//        }
//        [HttpGet("GetAttachmentById/{id}")]
//        public async Task<IActionResult> GetAttachmentById(int id)
//        {
//            return Ok(await _mediator.Send(new GetAttachmentByIdQuary { Id = id }));
//        }
//        [HttpGet("GetAllAttachments")]
//        public async Task<IActionResult> GetAllAttachments()
//        {
//            return Ok(await _mediator.Send(new GetAllAttachmentsQuary ()));
//        }
//    }
//}
