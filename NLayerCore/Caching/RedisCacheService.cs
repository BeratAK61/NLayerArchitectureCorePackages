using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace NLayerCore.Caching;

public class RedisCacheService : IRedisCacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task Clear(string key)
    {
        await _cache.RemoveAsync(key);
    }

    public async Task<byte[]> GetAsync(string key)
    {
        var response = await _cache.GetAsync(key);
        return response;
    }

    public async Task SetAsync(string key, object data, TimeSpan expiration)
    {
        byte[] value = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));

        await _cache.SetAsync(key, value, new DistributedCacheEntryOptions() { SlidingExpiration = expiration });
    }

}