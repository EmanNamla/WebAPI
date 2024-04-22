using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public int? AttachmentId { get; set; }

        public Attachment Attachment { get; set; }
        public Status Status { get; set; }
    }
}
