using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Request;

namespace NotificationService.Application.UseCases.Notifications.Command.CreateNotification
{
    public class CreateNotificationCommand : CommandDto<PostCommand>, IRequest<NotifOutput>
    {

    }

    public class PostCommand
    {
        [Required]
        public string title { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int from { get; set; }
        public List<TargetCommand> target { get; set; }
    }

    public class TargetCommand
    {
        public int id { get; set; }
        public string email_destination { get; set; }
    }
}
