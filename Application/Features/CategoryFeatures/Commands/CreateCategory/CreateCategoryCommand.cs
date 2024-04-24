using Domain.DTOs;
using Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public record CreateCategoryCommand:IRequest<CategoryDto>
    {

        public string Name { get; set; }

        public Status Status { get; set; }

    }
}
