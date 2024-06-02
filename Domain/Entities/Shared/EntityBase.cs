using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
    class EntityBase
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}
