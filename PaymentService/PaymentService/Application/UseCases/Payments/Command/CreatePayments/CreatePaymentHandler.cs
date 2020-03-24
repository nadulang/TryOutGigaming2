using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using PaymentService.Application.Models.Query;
using PaymentService.Application.UseCases.Payments.Request;
using PaymentService.Domain.Entities;
using PaymentService.Infrastructure.Persistences;
using RabbitMQ.Client;

namespace PaymentService.Application.UseCases.Payments.Command.CreatePayments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, PaymentDto>
    {
        private readonly PaymentContext _context;


        public CreatePaymentHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var input = request.Data.Attributes;

            var payment = new PaymentModel()
            {
                payment_type = input.payment_type,
                gross_amount = input.gross_amount,
                bank = input.bank,
                order_id = input.order_id
            };

            _context.AllPayments.Add(payment);
            await _context.SaveChangesAsync();

            var p = _context.AllPayments.First(x => x.transaction_status == input.transaction_status);
            var target = new TargetCommand() { id = p.id };
            var client = new HttpClient();

            var command = new NotificationAndLogsModel()
            {
                title = "rabbit-test",
                message = "this is only testing",
                type = "email",
                from = 98780,
                target = new List<TargetCommand>() { target }
            };

            var attributes = new Attribute<NotificationAndLogsModel>()
            {
                Attributes = command
            };

            var httpContent = new CommandDto<NotificationAndLogsModel>()
            {
                Data = attributes
            };

            var jsonObject = JsonConvert.SerializeObject(httpContent);
            //var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            //await client.PostAsync("http://localhost:7800/notification", content);


            var factory = new ConnectionFactory() { HostName = "notification-container" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "halonot", "fanout");

                channel.QueueDeclare(queue: "notification", durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind("notification", "halonot", routingKey: "");

                var body = Encoding.UTF8.GetBytes(jsonObject);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "halonot",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);


                Console.WriteLine("Message has sent");

                return new PaymentDto
                {
                    message = "Success add a payment data",
                    success = true
                };
            }
        }
    }
}
    

