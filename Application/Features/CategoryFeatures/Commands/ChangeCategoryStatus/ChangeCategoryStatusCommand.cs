using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.ChangeStatus
{
    public record ChangeCategoryStatusCommand:IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }
}
