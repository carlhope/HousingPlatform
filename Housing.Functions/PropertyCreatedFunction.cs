using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using Housing.Contracts.Events.Properties;
using Housing.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;


namespace Housing.Functions;

public class PropertyCreatedFunction
{
    private readonly ILogger<PropertyCreatedFunction> _logger;
    private readonly ICacheService _cache;

    public PropertyCreatedFunction(ILogger<PropertyCreatedFunction> logger, ICacheService cache)
    {
        _logger = logger;
        _cache = cache;
    }
    
    [Function("PropertyCreatedFunction")]
    public async Task RunAsync(
        [RabbitMQTrigger("PropertyCreatedEvent", ConnectionStringSetting = "RabbitMqConnection")]
        byte[] body)
    {
        var json = Encoding.UTF8.GetString(body);

        PropertyCreatedEvent? evt;
        try
        {
            evt = JsonSerializer.Deserialize<PropertyCreatedEvent>(json);
            if (evt is null)
            {
                _logger.LogError("Failed to deserialize PropertyCreatedEvent. Raw: {Json}", json);
                return;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Invalid JSON for PropertyCreatedEvent. Raw: {Json}", json);
            return;
        }

        _logger.LogInformation("Processing PropertyCreatedEvent for PropertyId {Id}", evt.PropertyId);

        // invalidate Redis
        await _cache.RemoveAsync("properties:all");
        await _cache.RemoveAsync($"properties:landlord:{evt.LandlordId}");
        await _cache.RemoveAsync($"properties:owner:{evt.OwnerId}");
    }

}
