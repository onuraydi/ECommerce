using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ECommerce.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",

            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("kuyruk1",false,false,false,null);
            var messageContent = "Merhaba, bu bir rabitMQ kuyruk mesajıdır.";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange:"", routingKey:"kuyruk1", basicProperties:null ,body:byteMessageContent);

            return Ok("Mesajınız sıraya alınmıştır");
        }

        private static string message;

        [HttpGet]
        public IActionResult ReadMessage()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";


            var connection = factory.CreateConnection();    

            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, body) =>
            {
                var byteMessage = body.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };

            channel.BasicConsume(queue: "kuyruk1", autoAck: false, consumer: consumer);

            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            return Ok(message);

        }
    }
}
