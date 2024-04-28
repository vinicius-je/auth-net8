using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class UserInputDTO { 
        public string Email {  get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    };
}
