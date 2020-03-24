using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Request;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommand : CommandDto<PutCommand>, IRequest<NotifOutput>
    {
        public UpdateNotificationCommand()
        {
        }
    }

    public class PutCommand
    {
        [Required]
        public int notification_id { get; set; }
        public DateTime read_at { get; set; }
        public List<Target> target { get; set; }
    }

    public class Target
    {
        public int id { get; set; }
    }
}
