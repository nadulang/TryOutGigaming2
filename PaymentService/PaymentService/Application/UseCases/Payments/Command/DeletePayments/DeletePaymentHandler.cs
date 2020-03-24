using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentService.Application.UseCases.Payments.Request;
using PaymentService.Infrastructure.Persistences;

namespace PaymentService.Application.UseCases.Payments.Command.DeletePayments
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, PaymentDto>
    {
        private readonly PaymentContext _context;

        public DeletePaymentHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<PaymentDto> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.AllPayments.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.AllPayments.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new PaymentDto
                {
                    success = true,
                    message = "Successfully deleted a payment"
                };

            }
        }
    }
}
