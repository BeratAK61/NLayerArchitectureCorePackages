using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLayerCore.Caching;
using NLayerCore.Security;

namespace NLayerCore;

public static class NLayerCoreServiceRegistration
{
    public static IServiceCollection AddJsonWebTokenAuthentication(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var jwtSettings = ConfigurationReader.GetJwtSettings();

            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                //ValidateAudience = true,
                ValidateAudience = false,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audiences[0],
                IssuerSigningKey = SignService.GetSymetricSecurityKey(jwtSettings.SecurityKey),
                ClockSkew = TimeSpan.Zero
            };
        });

        //services.AddAuthorization();

        return services;
    }

    public static IServiceCollection AddRedisCache(this IServiceCollection services)
    {
        services.AddScoped<IRedisCacheService, RedisCacheService>();

        var redisSettings = ConfigurationReader.GetRedisSettings();

        services.AddStackExchangeRedisCache(options => {

            options.Configuration = redisSettings.ConnectionString;
        });

        return services;



    }
}
