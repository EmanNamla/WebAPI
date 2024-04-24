using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int CategoryId):IRequest<Unit>;

}
