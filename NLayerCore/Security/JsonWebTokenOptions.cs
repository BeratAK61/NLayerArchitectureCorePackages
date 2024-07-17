namespace NLayerCore.Security;

public class JsonWebTokenOptions
{
    public List<string> Audiences { get; set; }

    public string Issuer { get; set; }

    /// <summary>
    /// Access Token Expiration Time in Minutes
    /// </summary>
    public int AccessTokenExpiration { get; set; }

    /// <summary>
    /// Access Token Expiration Time in Minutes
    /// </summary>
    public int RefreshTokenExpiration { get; set; }

    public string SecurityKey { get; set; }
}
