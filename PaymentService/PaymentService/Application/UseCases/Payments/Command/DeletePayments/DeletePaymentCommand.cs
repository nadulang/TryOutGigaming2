using MediatR;
using PaymentService.Application.UseCases.Payments.Request;

namespace PaymentService.Application.UseCases.Payments.Command.DeletePayments
{
    public class DeletePaymentCommand : IRequest<PaymentDto>
    {
        public int Id { get; set; }

        public DeletePaymentCommand(int id)
        {
            Id = id;
        }
    }
}
