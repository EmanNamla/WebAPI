using Domain.DTOs;
using Domain.Entities.Identity;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.CreateProduct
{
    public record CreateProductCommand:IRequest<ProductDto>
    {

        public string Name { get; set; }

        public Status Status { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }

    }
}
