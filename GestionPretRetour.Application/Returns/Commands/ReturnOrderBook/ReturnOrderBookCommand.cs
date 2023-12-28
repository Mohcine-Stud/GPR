using GestionPretRetour.Domain.OrderAggregate.Entities;
using MediatR;

namespace GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;

public record ReturnOrderBookCommand(
    Guid UserId,
    Guid OrderBookId
    ):IRequest<OrderBook>;
