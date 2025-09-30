using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Security;

public class JwtHandler
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtHandler(string key, string issuer, string audience)
    {
        _key = key;
        _issuer = issuer;
        _audience = audience;
    }

    public string GenerateToken(string username)
    {
        var claims = new[] { new Claim(ClaimTypes.Name, username) };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
