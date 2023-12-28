using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionPretRetour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;

        public OrdersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await Task.CompletedTask;

            var createOrderResult = _mediator.Send(command);


            return Ok(createOrderResult);
        }
    }
}
