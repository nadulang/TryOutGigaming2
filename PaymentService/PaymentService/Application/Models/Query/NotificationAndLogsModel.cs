using System.Collections.Generic;

namespace PaymentService.Application.Models.Query
{
    public class NotificationAndLogsModel
    {
        public string title { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public List<TargetCommand> target { get; set; }
    }

    public class TargetCommand
    {
        public int id { get; set; }
    }
}
