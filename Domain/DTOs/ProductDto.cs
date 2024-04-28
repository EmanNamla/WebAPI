using Domain.Entities.Identity;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductDto
    {

        public string Name { get; set; }

        public string Status { get; set; }
        public int Quantity { get; set; }

        public decimal Price  { get; set; }
        public int CategoryId { get; set; }


        public int? AttachmentId { get; set; }

     
    }
}
