using CRM_Notification.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Notification.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(NotificationRequest request);
    }

}
