using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PaymentService.Infrastructure.Persistences;

namespace PaymentService.Application.UseCases.Payments.Queries.GetAllPayments
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, GetAllPaymentsDto>
    {
        private readonly PaymentContext _context;

        public GetAllPaymentsQueryHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<GetAllPaymentsDto> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var allpayment = await _context.AllPayments.ToListAsync();

            return new GetAllPaymentsDto()
            {
                message = "Payment successfully retrieved",
                success = true,
                Data = allpayment
            };
        }
    }
}
