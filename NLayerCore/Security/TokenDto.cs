namespace NLayerCore.Security;

public class TokenDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }


    public TokenDto(string accessToken, DateTime accessTokenExpiration, string refreshToken, DateTime refreshTokenExpiration)
    {
        AccessToken = accessToken;
        AccessTokenExpiration = accessTokenExpiration;
        RefreshToken = refreshToken;
        RefreshTokenExpiration = refreshTokenExpiration;
    }
}
