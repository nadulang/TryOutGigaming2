using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentService.Infrastructure.Persistences;

namespace PaymentService.Application.UseCases.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, GetPaymentByIdDto>
    {
        private readonly PaymentContext _context;

        public GetPaymentByIdQueryHandler(PaymentContext context)
        {
            _context = context;
        }

        public async Task<GetPaymentByIdDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.AllPayments.FindAsync(request.Id);

            return new GetPaymentByIdDto()
            {
                message = "Payment successfully retrieved",
                success = true,
                Data = data
            };
        }
    }
}
