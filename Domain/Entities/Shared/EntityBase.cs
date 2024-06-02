using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Shared
{
   public class EntityBase
    {
        public string CreatedBy { get; set; } = "222";
        public DateTime CreatedDate { get; set; }= DateTime.Now;

        public string ModifyBy { get; set; } = "222";
        public DateTime ModifyDate { get; set; } = DateTime.Now;

    }
}
