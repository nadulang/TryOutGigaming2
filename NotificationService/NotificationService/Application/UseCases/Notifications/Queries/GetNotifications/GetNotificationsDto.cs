using System.Collections.Generic;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Request;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetNotifications
{
    public class GetNotificationsDto : BaseDto
    {
        public List<NotificationInput> Data { get; set; }
    }
}
