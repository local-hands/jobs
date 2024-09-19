using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using localhands.Jobs.Models;


public class JobConsumer
{
    private readonly string _hostname = "localhost";  // RabbitMQ host
    private readonly string _queueName = "job_queue"; // Queue to receive jobs

    public void ConsumeJobs()
    {
        var factory = new ConnectionFactory() { HostName = _hostname };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var job = JsonSerializer.Deserialize<Job>(message);
                ProcessJob(job);
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    private void ProcessJob(Job job)
    {
        // Save the job for workers or notify workers
        // dbContext.WorkerJobs.Add(job);
        // dbContext.SaveChanges();
        Console.WriteLine("Processed Job: " + job.Title);
    }
}
