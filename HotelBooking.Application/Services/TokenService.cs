using HotelBooking.Application.Configurations;
using HotelBooking.Domain.Entities;
using HotelBooking.Application.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;

        public TokenService(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
            var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Email,user.Email ?? ""),
            new (JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}" ?? ""),
            new (JwtRegisteredClaimNames.NameId, user.Id ?? ""),
            new (JwtRegisteredClaimNames.Aud, _tokenConfiguration.Audience),
            new (JwtRegisteredClaimNames.Iss, _tokenConfiguration.Issuer),
            new ("Jti", Guid.NewGuid().ToString()),
            new ("UserLevel", user.UserLevel.ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_tokenConfiguration.TimeToExpiry),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
