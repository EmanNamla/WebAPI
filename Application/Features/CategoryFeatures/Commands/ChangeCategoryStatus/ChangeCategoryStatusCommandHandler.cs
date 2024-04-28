using Application.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.ChangeStatus
{
    public class ChangeCategoryStatusCommandHandler : IRequestHandler<ChangeCategoryStatusCommand, Unit>
    {
        private readonly ICategoryService _categoryService;

        public ChangeCategoryStatusCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<Unit> Handle(ChangeCategoryStatusCommand command, CancellationToken cancellationToken)
        {
           await _categoryService.ChangeCategoryStatusAsync(command.CategoryId);
            return Unit.Value;
        }
    }
}
