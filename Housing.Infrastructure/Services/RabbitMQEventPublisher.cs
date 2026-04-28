using System.Text.Json;
using RabbitMQ.Client;
using Housing.Infrastructure.Services.Interfaces;

namespace Housing.Infrastructure.Services;

public class RabbitMqEventPublisher : IEventPublisher, IDisposable
{
    private readonly IConnection _connection;
    private readonly IChannel _channel;

    public RabbitMqEventPublisher(Task<IConnection> connectionTask)
    {
        _connection = connectionTask.GetAwaiter().GetResult();
        _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
    }

    public async Task PublishAsync<T>(T message) where T : class
    {
        var queueName = typeof(T).Name;

        await _channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var body = JsonSerializer.SerializeToUtf8Bytes(message);

        await _channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            body: body
        );
  
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}




