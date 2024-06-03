using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Domain.Entities.Shared;

namespace Domain.Entities
{
    public class Attachment: EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }

        public int AttachmentGroupId { get; set; }

        public AttachmentGroup? attachmentGroup { get; set; }
    }
}
