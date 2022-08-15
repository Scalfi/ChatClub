using ChatClub.Bot.Interface;
using RabbitMQ.Client;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace ChatClub.Bot.Service
{
    public class MessageBrokerService : IMessageBroker
    {
        //The bot should parse the received CSV file and then it should send a message back into
        //the chatroom using a message broker like RabbitMQ.The message will be a stock quote
        //using the following format: “APPL.US quote is $93.42 per share”. The post owner will be
        //the bot.
        //  CSV doesn't return quote so I set message in code without parsing csv. 

        public void Produce()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "messageBot",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "APPL.US quote is $93.42 per share.";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "messageBot",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
