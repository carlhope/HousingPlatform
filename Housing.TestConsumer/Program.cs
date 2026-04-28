using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Starting RabbitMQ consumer...");

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
};

// Connect
var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

// Queue name must match publisher
var queueName = "PropertyCreatedEvent";

await channel.QueueDeclareAsync(
    queue: queueName,
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

Console.WriteLine($"Listening on queue: {queueName}");
Console.WriteLine("Waiting for messages...\n");

// Create consumer
var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"[x] Received: {message}");
    Console.ResetColor();

    // Acknowledge message
    await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
};

// Start consuming
await channel.BasicConsumeAsync(
    queue: queueName,
    autoAck: false,
    consumer: consumer
);

// Keep the app alive
await Task.Delay(Timeout.Infinite);

