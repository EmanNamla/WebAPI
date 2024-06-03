using Application.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AttachmentGroupFeatures.Commands.DeleteAttachment
{
    public class DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand>
    {
        private readonly IAttachmentGroupRepository _repository;

        public DeleteAttachmentCommandHandler(IAttachmentGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAttachmentAsync(request.GroupId, request.AttachmentId);
            return Unit.Value;
        }
    }
}
