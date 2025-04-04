using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Notification.Domain.Models
{
    public class NotificationRequest
    {
        public string Type { get; set; } // email, sms, push
        public string To { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; } // optional
    }

}
