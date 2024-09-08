using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TasksManagmentService.Models;

namespace TasksManagmentService.HelperServices;

public class TokenParseService
{
    public static UserIdentity ParseUserIdentity(string token)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, 
            ValidateAudience = false, 
            ValidateLifetime = false,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
        var userId = principal.Claims.FirstOrDefault(x => x.Type == "id")!.Value;
        var userName = principal.Claims.FirstOrDefault(x => x.Type == "userName")!.Value;
        return new UserIdentity()
        {
            user_id = userId,
            userName = userName
        };
    }
}