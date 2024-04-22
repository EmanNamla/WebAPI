using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }

        public AppUser? AppUser { get; set; }

        public Product? Product { get; set; }
    }
}
