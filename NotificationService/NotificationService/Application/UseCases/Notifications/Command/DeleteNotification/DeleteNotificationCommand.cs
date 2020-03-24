using MediatR;
using NotificationService.Application.UseCases.Notifications.Request;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<NotifOutput>
    {
        public int Id { get; set; }

        public DeleteNotificationCommand(int id)
        {
            Id = id;
        }
    }
}
