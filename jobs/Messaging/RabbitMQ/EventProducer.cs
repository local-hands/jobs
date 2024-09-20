using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using localhands.Jobs.Models;

namespace localhands.Jobs.Messaging.RabbitMQ;

public class JobProducer
{
    private readonly string _hostname = "localhost";  // RabbitMQ host
    private readonly string _queueName = "job_queue"; // Queue to send jobs

    public void SendJob(Job job)
    {
        var factory = new ConnectionFactory() { HostName = _hostname };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var message = JsonSerializer.Serialize(job);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            Console.WriteLine("RabbitMQ Producer [x] Sent {0}", message);
        }
    }
}
