using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionPretRetour.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReturnsController : ControllerBase
{
    private readonly ISender _mediator;

    public ReturnsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult> ReturnBook(ReturnOrderBookCommand command)
    {
        var returnBookResult = await _mediator.Send(command);
        return Ok(returnBookResult);
    }
}
