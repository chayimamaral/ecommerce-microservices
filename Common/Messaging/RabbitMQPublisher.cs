using System.Text;
using RabbitMQ.Client;

namespace Common.Messaging;

public class RabbitMQPublisher : IDisposable
{
    private readonly IConnection _connection;

    public RabbitMQPublisher(string hostname = "localhost")
    {
        var factory = new ConnectionFactory() { HostName = hostname };
        _connection = factory.CreateConnection();
    }

    public void Publish(string queueName, string message)
    {
        // Cria o canal temporariamente aqui, sem precisar da interface IModel
        using var channel = _connection.CreateModel();

        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: queueName,
            basicProperties: null,
            body: body);
    }

    public void Dispose()
    {
        _connection?.Close();
    }
}
