using System.Text.Json;
using Housing.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Housing.Infrastructure.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _db;
    private readonly ILogger<RedisCacheService> _logger;

    public RedisCacheService(IConnectionMultiplexer mux, ILogger<RedisCacheService> logger)
    {
        _db = mux.GetDatabase();
        _logger = logger;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _db.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;
        
        var str = value.ToString();

        return JsonSerializer.Deserialize<T>(str);
    }
    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value);

        var expiration = expiry.HasValue
            ? new Expiration(expiry.Value)
            : new Expiration(TimeSpan.FromMinutes(30));
        if (!expiry.HasValue)
        {
            _logger.LogWarning("Cache key {Key} set without explicit TTL. Using default 30 minutes.", key);
        }


        await _db.StringSetAsync(key, json, expiration);
    }



    public async Task RemoveAsync(string key)
    {
        await _db.KeyDeleteAsync(key);
    }
}