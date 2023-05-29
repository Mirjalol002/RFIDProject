using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RFID.Application.Abstractions;
using RFID.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RFID.Infrastructure.Services
{
    public class JWTService : ITokenService
    {
        private readonly JWTConfiguration _configuration;
        public JWTService(IOptions<JWTConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public string GetAccessToken(Claim[] userClaims)
        {
            var jwtClaims = new Claim[]
{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
};

            var claims = userClaims.Concat(jwtClaims);

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration.ValidIssuer,
                _configuration.ValidAudience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}