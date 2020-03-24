using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.UseCases.Payments.Command.CreatePayments;
using PaymentService.Application.UseCases.Payments.Command.DeletePayments;
using PaymentService.Application.UseCases.Payments.Command.UpdatePayments;
using PaymentService.Application.UseCases.Payments.Queries.GetAllPayments;
using PaymentService.Application.UseCases.Payments.Queries.GetPaymentById;

namespace PaymentService.Presenter.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;

        public PaymentController(IMediator mediatr)
        {
            _mediatr = mediatr;

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _mediatr.Send(new GetAllPaymentsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var command = new GetPaymentByIdQuery(id);
            var result = await _mediatr.Send(command);
            return result != null ? (ActionResult)Ok(new { Message = "success", data = result }) : NotFound(new { Message = "not found" });

        }

        [HttpPost("midtrans/push")]
        public async Task<IActionResult> Post(CreatePaymentCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediatr.Send(command);

            return command != null ? (IActionResult)Ok(new { Message = "deleted" }) : NotFound(new { Message = "not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePaymentCommand req)
        {

            req.Data.Attributes.id = id;
            var result = await _mediatr.Send(req);
            return Ok(result);

        }
    }
}
