using GestionPretRetour.Domain.OrderAggregate;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using MediatR;

namespace GestionPretRetour.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Order>
{
    private readonly List<Order> _orders = new();
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //creae order
        var order = Order.Create( 
            request.UserId,
            request.Books.ConvertAll(book => OrderBook.Create(
                book.Id,
                book.ExpectedReturnDate
                ))
            );
        //persist order to db
        _orders.Add(order);
        //return createOrderResult if needed
        return order;
    }
}
