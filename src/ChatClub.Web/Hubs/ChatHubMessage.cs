using Microsoft.AspNetCore.SignalR;
using ChatClub.Domain.Interfaces.Services;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace ChatClub.Web.Hubs
{
    public class ChatHubMessage : Hub
    {
        private readonly IApiService _api;

        public ChatHubMessage(IApiService api)
        {
            _api = api;
        }

        
        public async Task SendMessage(string user, string message)
        {

            if (message.Contains("/stock="))
                await _api.GetAsync(message);


            await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));
        }


        public async Task SendMessageBot()
        {
            string? message = null;
            string user = "Bot";
            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "messageBot",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);
                };

                channel.BasicConsume(queue: "messageBot",
                            autoAck: true,
                            consumer: consumer);
            }
            if (message != null)
                await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));   

        }
    }
}
