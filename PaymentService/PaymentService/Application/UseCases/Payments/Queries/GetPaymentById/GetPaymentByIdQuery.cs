using MediatR;

namespace PaymentService.Application.UseCases.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<GetPaymentByIdDto>
    {
        public int Id { get; set; }

        public GetPaymentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
