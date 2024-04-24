using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.GetAllProducts
{
    public record GetAllProductsQuary:IRequest<IEnumerable<ProductDto>>;
   
}
