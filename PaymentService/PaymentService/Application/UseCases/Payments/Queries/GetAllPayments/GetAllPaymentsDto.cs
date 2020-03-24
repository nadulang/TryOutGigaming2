using System.Collections.Generic;
using PaymentService.Application.Models.Query;
using PaymentService.Domain.Entities;

namespace PaymentService.Application.UseCases.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsDto : BaseDto
    {
        public List<PaymentModel> Data { get; set; }
    }
}
