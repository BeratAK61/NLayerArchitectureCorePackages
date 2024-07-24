using Microsoft.Extensions.Configuration;
using NLayerCore.Caching;
using NLayerCore.Security;

namespace NLayerCore;

public class ConfigurationReader
{
    public static IConfigurationRoot GetAppSettings()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
        return builder.Build();
    }

    public static JsonWebTokenOptions GetJwtSettings()
    {
        var config = GetAppSettings();
        var jwtSettings = new JsonWebTokenOptions();
        config.Bind("JsonWebTokenOptions", jwtSettings);
        return jwtSettings;
    }

    public static RedisOptions GetRedisSettings()
    {
        var config = GetAppSettings();
        var redisSettings = new RedisOptions();
        config.Bind("RedisOptions", redisSettings);
        return redisSettings;
    }
}
