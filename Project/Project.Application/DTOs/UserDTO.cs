using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new();
        public string Token { get; set; } = string.Empty;
        public Guid? RefreshToken { get; set; }
    }
}
