using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Proto.Arguments.Arguments.Module.Registration;
using Proto.Arguments.General.Session;

namespace Proto.Domain.Extension;

public static class JwtExtension
{
    public static string GenerateJwtToken(OutputUser user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim("UserId", user.Id.ToString()),
        };

        return GenerateJwtToken(claims);
    }

    public static string GenerateJwtToken(List<Claim> claims)
    {
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SessionData.Configuration!["Jwt:Key"]!));
        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: SessionData.Configuration!["Jwt:Issuer"],
            audience: SessionData.Configuration!["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        TokenValidationParameters tokenValidaitonParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = SessionData.Configuration!["Jwt:Issuer"],
            ValidAudience = SessionData.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SessionData.Configuration["Jwt:Key"]!))
        };

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidaitonParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid Token");

        return principal;
    }

    public static string GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[32];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}