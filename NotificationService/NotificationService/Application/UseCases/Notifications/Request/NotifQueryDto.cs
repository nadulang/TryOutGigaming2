using System;
using System.Collections.Generic;

namespace NotificationService.Application.UseCases.Notifications.Request
{
    public class NotifQueryDto 
    {
        public int total { get; set; }
        public int read_count { get; set; }
        public NotificationInput notification { get; set; }
        public List<LogsInput> logs { get; set; }
    }

    public class NotificationInput
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }

    public class LogsInput
    {
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public DateTime read_at { get; set; }
    }
}
