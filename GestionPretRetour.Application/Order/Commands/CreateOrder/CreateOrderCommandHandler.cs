using GestionPretRetour.Application.Orders.Services;
using GestionPretRetour.Domain.OrderAggregate;
using MediatR;

namespace GestionPretRetour.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Order>
{
    private readonly ICreateOrderService _createOrderService;

    public CreateOrderCommandHandler(ICreateOrderService createOrderService)
    {
        _createOrderService = createOrderService ?? throw new ArgumentNullException(nameof(ICreateOrderService)); ;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var createdOrder = await _createOrderService.CreateOrder(request);

        return createdOrder;
    }
}
