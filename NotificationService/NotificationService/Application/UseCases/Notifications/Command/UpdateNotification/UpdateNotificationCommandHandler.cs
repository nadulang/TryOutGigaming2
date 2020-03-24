using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.UseCases.Notifications.Request;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, NotifOutput>
    {

        private NotificationContext _context;

        public UpdateNotificationCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<NotifOutput> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationLogs = _context.Logs.ToList();

            var find = notificationLogs.Where(x => x.notification_id == request.Data.Attributes.notification_id);

            foreach (var x in request.Data.Attributes.target)
            {
                var data = find.First(y => y.target == x.id).id;
                var dataContext = await _context.Logs.FindAsync(data);
                dataContext.read_at = request.Data.Attributes.read_at;
                await _context.SaveChangesAsync();
            }

            return new NotifOutput()
            {
                message = "Notification has been changed",
                success = true
            };
        }
    }
}