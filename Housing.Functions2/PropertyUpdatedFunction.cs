using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using Housing.Contracts.Events.Properties;
using Housing.Infrastructure.Services.Interfaces;

namespace Housing.Functions;

public class PropertyUpdatedFunction
{
    private readonly ILogger<PropertyUpdatedFunction> _logger;
    private readonly ICacheService _cache;

    public PropertyUpdatedFunction(
        ILogger<PropertyUpdatedFunction> logger,
        ICacheService cache)
    {
        _logger = logger;
        _cache = cache;
    }

    [Function("PropertyUpdatedFunction")]
    public async Task RunAsync(
        [RabbitMQTrigger("PropertyUpdatedEvent", ConnectionStringSetting = "RabbitMqConnection")]
        string data, FunctionContext context)
    {

        PropertyUpdatedEvent? evt;
        try
        {
            evt = JsonSerializer.Deserialize<PropertyUpdatedEvent>(data);
            if (evt is null)
            {
                //_logger.LogError("Failed to deserialize PropertyUpdatedEvent. Raw: {body}", body);
                return;
            }
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Invalid JSON for PropertyUpdatedEvent. Raw: {body}", body);
            return;
        }

        _logger.LogInformation("Processing PropertyUpdatedEvent for PropertyId {Id}", evt.PropertyId);

        // Invalidate Redis caches affected by property updates
        await _cache.RemoveAsync($"properties:{evt.PropertyId}");
        await _cache.RemoveAsync("properties:all");
        await _cache.RemoveAsync($"properties:landlord:{evt.LandlordId}");
        await _cache.RemoveAsync($"properties:owner:{evt.OwnerId}");

    }
}