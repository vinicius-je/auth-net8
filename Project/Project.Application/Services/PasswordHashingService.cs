using Microsoft.AspNetCore.Identity;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services
{
    public class PasswordHashingService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public PasswordHashingService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public PasswordVerificationResult VerifyPassword(string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        }
    }

}
