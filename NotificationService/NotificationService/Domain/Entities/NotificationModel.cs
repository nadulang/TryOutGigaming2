namespace NotificationService.Domain.Entities
{
    public class NotificationModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}
