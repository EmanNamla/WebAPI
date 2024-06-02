using Domain.DTOs;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int AttachmentGroupId { get; set; }

        public virtual AttachmentGroup  AttachmentGroup { get; set; }

        public Product(ProductDto productDto)
        {


        }

        void HandleAddUpdateSubItems()
        {

        }

        public void ChangeStatus()
        {
            Status = Status == Status.Active ? Status.Inactive : Status.Active;
        }


    }
}
