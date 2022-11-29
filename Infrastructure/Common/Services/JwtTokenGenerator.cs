using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces;
using Infrastructure.Common.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Common.Services
{
  public class JwtTokenGenerator : IJwtTokenGenerator
  {
    private readonly ConfigSettings _config;

    public JwtTokenGenerator(IOptions<ConfigSettings> configOptions)
    {
      _config = configOptions.Value;
    }

    public string GenerateToken(int userId, string fullName, string email)
    {
      var signingCredentials = new SigningCredentials(
        new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(_config.Secret)
        ), SecurityAlgorithms.HmacSha256
      );

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, email),
        new Claim(JwtRegisteredClaimNames.GivenName, fullName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      };

      var securityToken = new JwtSecurityToken(
        issuer: _config.Issuer,
        audience: _config.Audience,
        expires: DateTime.Now.AddMinutes(_config.ExpirationTimeInMinutes),
        claims: claims,
        signingCredentials: signingCredentials
      );

      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
  }
}