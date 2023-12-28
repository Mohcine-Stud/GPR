using GestionPretRetour.Application.Returns.Services;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using MediatR;

namespace GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;

public class ReturnOrderBookCommandHandler : IRequestHandler<ReturnOrderBookCommand, OrderBook>
{
    private readonly IReturnOrderBooksService _returnOrderBookservice;

    public ReturnOrderBookCommandHandler(IReturnOrderBooksService returnOrderBookservice)
    {
        _returnOrderBookservice = returnOrderBookservice ?? throw new ArgumentNullException(nameof(returnOrderBookservice));
    }

    public async Task<OrderBook> Handle(ReturnOrderBookCommand request, CancellationToken cancellationToken)
    {
        var returnOrderBookResult = await _returnOrderBookservice.ReturnOrderBook(request);
        return (returnOrderBookResult);
    }
}
