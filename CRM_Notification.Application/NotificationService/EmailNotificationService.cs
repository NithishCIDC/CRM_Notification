using CRM_Notification.Application.Interfaces;
using CRM_Notification.Domain.Models;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;


namespace CRM_Notification.Application.NotificationService
{
    public class EmailNotificationService : INotificationService
    {
        public async Task SendAsync(NotificationRequest request)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("CRM", "theboyscidc@gmail.com"));
            email.To.Add(new MailboxAddress("",request.To));
            email.Subject = request.Subject;

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<h2>Hello!</h2><p>{request.Message}</p>"
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("theboyscidc@gmail.com", "zfgrjyxnctdhssxo");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }

}
