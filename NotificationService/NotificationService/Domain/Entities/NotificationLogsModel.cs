using System;
namespace NotificationService.Domain.Entities
{
    public class NotificationLogsModel
    {
        public int id { get; set; }
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public string email_destination { get; set; }
        public DateTime read_at { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }

        public NotificationModel notification { get; set; }
    }
}
