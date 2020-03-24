using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Request;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, NotifOutput>
    {
        private NotificationContext _context;

        public CreateNotificationCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<NotifOutput> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            
            var notificationList = _context.Notifications.ToList();

            var notificationData = new NotificationModel()
            {
                message = request.Data.Attributes.message,
                title = request.Data.Attributes.title
            };

            if (!notificationList.Any(x => x.title == request.Data.Attributes.title))
            {
                _context.Notifications.Add(notificationData);
            }
            await _context.SaveChangesAsync();

            
            var in_notif = _context.Notifications.First(x => x.title == request.Data.Attributes.title);
            foreach (var x in request.Data.Attributes.target)
            {
                _context.Logs.Add(new NotificationLogsModel
                {
                    notification_id = in_notif.id,
                    type = request.Data.Attributes.type,
                    from = request.Data.Attributes.from,
                    target = x.id,
                    email_destination = x.email_destination
                });

                await _context.SaveChangesAsync();
                await SendMail("nadyarichna@gigaming.io", x.email_destination, request.Data.Attributes.title, request.Data.Attributes.message);
            }

            await _context.SaveChangesAsync();

            return new NotifOutput()
            {
                message = "Successfully Added",
                success = true
            };
        }

        
        public async Task<List<PaymentData>> GetPaymentData()
        {
            var client = new HttpClient();
            var data = await client.GetStringAsync("http://localhost:7500/payment");
            return JsonConvert.DeserializeObject<List<PaymentData>>(data);
        }

     
        public async Task SendMail(string emailfrom, string emailto, string subject, string body)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("84b015139889ab", "a7eda17f7b7703"),
                EnableSsl = true
            };
            await client.SendMailAsync(emailfrom, emailto, subject, body);
            Console.WriteLine("Email has been sent");
        }
    }
}
