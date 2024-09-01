using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GatewayAPI.HelperServices
{

    public class JwtTokenGenerator
    {
        public string generateJWTtoken(List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
           issuer: AuthOptions.ISSUER,
           audience: AuthOptions.AUDIENCE,
           claims: claims,
           expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
           signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
           return $"Bearer {new JwtSecurityTokenHandler().WriteToken(jwt)}";
        }
        public ClaimsPrincipal GetClaimsFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null or empty.");
            }

            try
            {
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ValidateLifetime = false,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                return principal;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to validate token.", ex);
            }
        }
    }
}
