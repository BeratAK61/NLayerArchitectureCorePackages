using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NLayerCore.Security;

internal static class SignService
{
    internal static SecurityKey GetSymetricSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
