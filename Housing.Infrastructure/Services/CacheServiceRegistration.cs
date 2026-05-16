using Housing.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Housing.Infrastructure.Services;

public static class CacheServiceRegistration
{
    public static IServiceCollection AddRedisCaching(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IConnectionMultiplexer>(_ =>
            ConnectionMultiplexer.Connect(connectionString));

        services.AddSingleton<ICacheService, RedisCacheService>();

        return services;
    }
}