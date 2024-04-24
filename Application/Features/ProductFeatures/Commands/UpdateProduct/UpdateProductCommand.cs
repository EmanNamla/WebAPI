using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public record UpdateProductCommand(int ProductId, ProductDto ProductDto) : IRequest<ProductDto>;


}
