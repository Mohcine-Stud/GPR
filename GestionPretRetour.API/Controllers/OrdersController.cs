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
            var createOrderResult = await _mediator.Send(command);

            if(createOrderResult == null)
            {
                return BadRequest("no order has been created...!");
            }

            return Ok(createOrderResult);
        }
    }
}
