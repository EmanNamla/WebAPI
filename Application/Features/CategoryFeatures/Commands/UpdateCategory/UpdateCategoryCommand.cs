using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(int CategoryId, CategoryDto CategoryDto) : IRequest<CategoryDto>
    {
    }
}
