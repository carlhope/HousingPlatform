using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;


namespace Housing.Functions;

public class PropertyCreatedFunction
{
    private readonly ILogger<PropertyCreatedFunction> _logger;

    public PropertyCreatedFunction(ILogger<PropertyCreatedFunction> logger)
    {
        _logger = logger;
    }

    [Function("PropertyCreatedFunction")]
    public void Run(
        [RabbitMQTrigger("PropertyCreatedEvent", ConnectionStringSetting = "RabbitMqConnection")]
        byte[] body)
    {
        var message = Encoding.UTF8.GetString(body);

        _logger.LogInformation("Received PropertyCreatedEvent: {Message}", message);

        // TODO: deserialize JSON if needed
        // TODO: optional Redis invalidation
        // TODO: optional background processing
    }
}
