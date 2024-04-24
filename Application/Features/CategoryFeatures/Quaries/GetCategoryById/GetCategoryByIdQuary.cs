using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.GetCategoryById
{
    public record GetCategoryByIdQuary(int CategoryId) :IRequest<CategoryDto>;
}
