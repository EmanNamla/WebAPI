using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AttachmentDto
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public string Extension { get; set; }
    }
}
