using Project.Domain.Entities;

namespace Project.Application.UseCases.DTOs
{
    public class Response
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Role> Roles { get; set; } = new();
        public string Token { get; set; } = string.Empty;
        public Guid? RefreshToken { get; set; }
    }
}
