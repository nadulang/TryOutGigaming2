using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.UseCases.Notifications.Request;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, NotifOutput>
    {
        private NotificationContext _context;

        public DeleteNotificationCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<NotifOutput> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Notifications.FindAsync(request.Id);
            _context.Notifications.Remove(data);

            return new NotifOutput()
            {
                message = "Data has been deleted",
                success = true
            };
        }

    }
}
