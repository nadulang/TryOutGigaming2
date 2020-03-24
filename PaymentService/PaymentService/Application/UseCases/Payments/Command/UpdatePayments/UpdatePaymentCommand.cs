using MediatR;
using PaymentService.Application.Models.Query;
using PaymentService.Application.UseCases.Payments.Request;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases.Payments.Command.UpdatePayments
{
    public class UpdatePaymentCommand : CommandDto<PaymentModel>, IRequest<PaymentDto>
    {
        
    }
}
