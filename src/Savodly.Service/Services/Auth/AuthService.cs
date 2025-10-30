using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Savodly.Service.Services.Settings;

namespace Savodly.Service.Services.Auth;

public class AuthService(ISettingService settingService) : IAuthService
{
    public async Task<string> GenerateToken(string id, EntityType type)
    {
        var configuration = await settingService.GetByCategoryAsync("JWT");
        var claims = new[]
        {
            new Claim("ID", id),
            new Claim("EntityType", type.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT.Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["JWT.Issuer"],
            audience: configuration["JWT.Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(configuration["JWT.ExpiresInMinutes"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
