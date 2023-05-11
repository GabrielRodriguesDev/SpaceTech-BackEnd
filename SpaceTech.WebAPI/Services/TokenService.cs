using Microsoft.IdentityModel.Tokens;
using SpaceTech.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SpaceTech.WebAPI.Services;

public class TokenService
{
    public static string GenerateJwtToken(HttpContext context, AuthenticatedModel authenticatedModel)
    {
        var service = context.RequestServices.GetRequiredService<IConfiguration>();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(service["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: service["Jwt:Issuer"],
            audience: service["Jwt:Audience"],
            claims: GrantingPermissions(authenticatedModel),
            expires: DateTime.UtcNow.AddHours(5),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static List<Claim> GrantingPermissions(AuthenticatedModel authenticatedModel)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.Name, authenticatedModel.Name),
            new Claim(ClaimTypes.Email, authenticatedModel.Email),
            new Claim("Id", authenticatedModel.Id)
        };
    }
}
