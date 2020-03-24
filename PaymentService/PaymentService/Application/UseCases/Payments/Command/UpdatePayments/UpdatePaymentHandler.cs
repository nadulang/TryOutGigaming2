using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentService.Application.UseCases.Payments.Request;
using PaymentService.Infrastructure.Persistences;

namespace PaymentService.Application.UseCases.Payments.Command.UpdatePayments
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, PaymentDto>
    {
        private readonly PaymentContext _context;

        public UpdatePaymentHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.AllPayments.FindAsync(request.Data.Attributes.id);

            data.transaction_id = request.Data.Attributes.transaction_id;
            data.payment_type = request.Data.Attributes.payment_type;
            data.gross_amount = request.Data.Attributes.gross_amount;
            data.transaction_time = DateTime.Now;
            _context.SaveChanges();

            return new PaymentDto()
            {
                message = "Payment has been modified",
                success = true
            };
        }
    }
}
