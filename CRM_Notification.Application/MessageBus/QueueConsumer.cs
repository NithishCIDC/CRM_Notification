using CRM_Notification.Application.Interfaces;
using CRM_Notification.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace CRM_Notification.Application.MessageBus
{
    public class QueueConsumer : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public QueueConsumer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Simulate receiving from a message queue
                var message = "{ \"Type\": \"email\", \"To\": \"user@example.com\", \"Message\": \"Hello!\", \"Subject\": \"Test\" }";

                var request = JsonSerializer.Deserialize<NotificationRequest>(message);

                using var scope = _scopeFactory.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<INotificationService>();
                //await service.SendAsync(request);

                await Task.Delay(10000, stoppingToken); // Simulate delay between messages
            }
        }
    }
}