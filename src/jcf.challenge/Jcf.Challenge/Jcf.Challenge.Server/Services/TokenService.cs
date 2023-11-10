using Jcf.Challenge.Server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jcf.Challenge.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClaimsIdentity GeneratorClaims(User user)
        {
            var cli = new ClaimsIdentity(new[]
                  {
                    new Claim("USER_ID", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("USER_NAME", user.Name)
                });

            return cli;

        }

        public string NewToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Authentication:Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GeneratorClaims(user),
                Expires = DateTime.UtcNow.AddDays(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

                Issuer = _configuration["Authentication:Jwt:Issuer"],
                Audience = _configuration["Authentication:Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
