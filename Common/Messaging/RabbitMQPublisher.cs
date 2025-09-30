using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Common.Messaging;

public class RabbitMQPublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

            public RabbitMQPublisher(string hostname = "localhost")
        {
            var factory = new ConnectionFactory() { HostName = hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish(string queueName, string message)
        {
            _channel.QueueDeclare(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
}
