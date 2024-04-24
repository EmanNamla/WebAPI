using Application.Interfaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
           await  _productService.DeleteProductAsync(command.productId);
            return Unit.Value;
        }
    }
}
