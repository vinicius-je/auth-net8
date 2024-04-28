using Project.Domain.Entities;

namespace Project.Application.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id {  get; set; }
        public string Email {  get; set; }
        public List<RoleResponseDTO> Roles { get; set; }
        public string? Token { get; set; }
        public Guid? RefreshToken { get; set; }
    }
}
