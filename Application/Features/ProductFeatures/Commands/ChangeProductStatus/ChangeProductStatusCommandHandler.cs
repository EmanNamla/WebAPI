using Application.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.ChangeProductStatus
{
    public class ChangeProductStatusCommandHandler : IRequestHandler<ChangeProductStatusCommand, Unit>
    {
        private readonly IProductService _productService;

        public ChangeProductStatusCommandHandler(IProductService productService)
        {
           _productService = productService;
        }
        public async Task<Unit> Handle(ChangeProductStatusCommand command, CancellationToken cancellationToken)
        {
            await _productService.ChangeProductStatusAsync(command.productId);
            return Unit.Value;
        }
    }
}
