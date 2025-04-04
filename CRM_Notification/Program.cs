using CRM_Notification.Application.NotificationService;
using Microsoft.Extensions.Hosting; // Add this using directive
using Microsoft.Extensions.DependencyInjection;
using CRM_Notification.Application.Interfaces;
using CRM_Notification.Application.MessageBus;
using NotificationService.MessageBus; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddHostedService<RabbitMqConsumer>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();