using GestionPretRetour.Domain.OrderAggregate;
using MediatR;

namespace GestionPretRetour.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid UserId,
    List<OrderBookCommand> Books) : IRequest<Order>;

public record OrderBookCommand(
    Guid Id,
    DateTime ExpectedReturnDate);

