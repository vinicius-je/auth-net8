using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Domain.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.WebApi.Extensions
{
    public static class JwtExtension
    {
        public static string Generate(UserResponseDTO data)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(data),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserResponseDTO user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim("Id", user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role.Name));

            return ci;
        }
    }
}
