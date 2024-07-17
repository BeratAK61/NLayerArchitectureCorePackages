using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerCore.Security;

namespace NLayerCore;

public static class NLayerCoreServiceRegistration
{
    public static IServiceCollection AddJsonWebTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            var jwtSettings = ConfigurationReader.GetJwtSettings();


            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audiences[0],
                IssuerSigningKey = SignService.GetSymetricSecurityKey(jwtSettings.SecurityKey),
                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}
