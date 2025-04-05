using CRM_Notification.Application.Interfaces;
using CRM_Notification.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace CRM_Notification.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] NotificationRequest request)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var notification = new NotificationRequest
            {
                To = request.To,
                Subject = request.Subject,
                Message = request.Message,
                Type = request.Type
            };

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(notification));
            channel.BasicPublish(exchange: "", routingKey: "notification-queue", basicProperties: null, body: body);
            Console.WriteLine("Message published.");
            return Ok("Notification sent");
        }
    }
}
