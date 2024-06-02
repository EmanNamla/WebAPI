using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entities;
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
        private readonly IProductRepository _productRepository;

        public ChangeProductStatusCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(ChangeProductStatusCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.productId);
            product.ChangeStatus();
            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
