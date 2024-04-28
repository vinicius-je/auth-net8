using Project.Application.Interfaces;

namespace Project.Application.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null) throw new ArgumentNullException(nameof(hashedPassword));
            if (providedPassword == null) throw new ArgumentNullException(nameof(providedPassword));

            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }
    }

}
