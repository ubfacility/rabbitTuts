using System;
using RabbitMQ.Client;
using System.Text;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection()){
                using(var channel =  connection.CreateModel()){
                    channel.QueueDeclare(queue: "Hello vic",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    string message = "Hello Victor";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                            routingKey: "Hello",
                                            basicProperties: null,
                                            body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
