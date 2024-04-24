using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Quaries.GetAllCategories
{
    public record GetAllCategoriesQuary : IRequest<IEnumerable<CategoryDto>>;
}
