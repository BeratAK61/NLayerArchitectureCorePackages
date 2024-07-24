namespace NLayerCore.Caching;

public interface IRedisCacheService
{
    Task<byte[]> GetAsync(string key);

    Task SetAsync(string key, object data, TimeSpan expiration); 
    
    Task Clear(string key);

}
