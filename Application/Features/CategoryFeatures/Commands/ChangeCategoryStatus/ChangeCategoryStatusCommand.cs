using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoryFeatures.Commands.ChangeStatus
{
    public class ChangeCategoryStatusCommand:IRequest<string>
    {
        public int CategoryId { get; set; }
    }
}
