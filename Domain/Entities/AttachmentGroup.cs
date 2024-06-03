using Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class AttachmentGroup: EntityBase
    {
        public int Id { get; set; }

        public List<Attachment> Attachments { get; set; }


    }
}
