using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace NLayerCore.Security;

public class TokenService : ITokenService
{
    
    public TokenDto CreateJwt(CreateTokenDto createTokenDto)
    {
        //JsonWebTokenOptions tokenOptions = createTokenDto.TokenOptions;

        var jwtSettings = ConfigurationReader.GetJwtSettings();

        var accessTokenExpiration = DateTime.Now.AddMinutes(jwtSettings.AccessTokenExpiration);
        var refreshTokenExpiration = DateTime.Now.AddMinutes(jwtSettings.RefreshTokenExpiration);

        SecurityKey securityKey = SignService.GetSymetricSecurityKey(jwtSettings.SecurityKey);

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            expires: accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: GetClaims(createTokenDto),
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        string token = handler.WriteToken(jwtSecurityToken);

        return new TokenDto(
            accessToken: token,
            refreshToken: CreateRefreshToken(),
            accessTokenExpiration: accessTokenExpiration,
            refreshTokenExpiration: refreshTokenExpiration);

    }

    private IEnumerable<Claim> GetClaims(CreateTokenDto createTokenDto)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, createTokenDto.UserId),
            new Claim(JwtRegisteredClaimNames.Email, createTokenDto.UserEmail),
            new Claim(ClaimTypes.Name, createTokenDto.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var role in createTokenDto.UserRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        }

        return claims;
    }

    private string CreateRefreshToken()
    {
        var numberByte = new Byte[32];

        using var rnd = RandomNumberGenerator.Create();  

        rnd.GetBytes(numberByte);

        return Convert.ToBase64String(numberByte);
    }
}
