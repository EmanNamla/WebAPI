using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.SearchProductByName
{
    public record SearchProductByNameQuary(string name):IRequest<IEnumerable<ProductDto>>;
   
}
