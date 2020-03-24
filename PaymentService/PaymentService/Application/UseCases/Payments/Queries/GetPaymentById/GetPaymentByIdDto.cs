using PaymentService.Application.Models.Query;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdDto : BaseDto
    {
        public PaymentModel Data { get; set; }
    }
}
