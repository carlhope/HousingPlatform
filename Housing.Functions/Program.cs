using Housing.Infrastructure.Services;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddRedisCaching(Environment.GetEnvironmentVariable("RedisConnection")??throw new InvalidOperationException());
    })
    .Build();

host.Run();