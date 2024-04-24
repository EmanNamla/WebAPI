using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Quaries.GetProductById
{
    public record GetProductByIdQuary(int id):IRequest<ProductDto>;
}
