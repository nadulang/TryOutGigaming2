using System.ComponentModel.DataAnnotations;
using MediatR;
using PaymentService.Application.Models.Query;
using PaymentService.Application.UseCases.Payments.Request;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases.Payments.Command.CreatePayments
{
    public class CreatePaymentCommand : CommandDto<PaymentModel>, IRequest<PaymentDto>
    {
        
    }

    public class PaymentRequest
    {
        [Required]
        public string payment_type { get; set; }
        [Required]
        public int gross_amount { get; set; }
        [Required]
        public string bank { get; set; }
        [Required]
        public int order_id { get; set; }
    }
}
