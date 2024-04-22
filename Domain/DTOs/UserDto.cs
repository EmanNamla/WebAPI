using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserDto
    {
        public UserDto()
        {

        }
        public UserDto(string email, string token)
        {
            Email = email;
            Token = token;
        }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
