using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate;

namespace GestionPretRetour.Application.Orders.Services;

public class CreateOrderService : ICreateOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public CreateOrderService(
        IOrderRepository orderRepository,
        IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public async Task<Order> CreateOrder(CreateOrderCommand command)
    {
        var user = await _userRepository.GetById( command.UserId );
        if( user == null )
        {
            var newUser = User.Create(command.UserId );
            await _userRepository.Add(newUser);
        }
        else
        {
            user.IncrementAttempts();
            await _userRepository.Update(command.UserId, user);
        }

        var order = Order.Create(
            command.UserId,
            command.Books.ConvertAll(book => OrderBook.Create(
                book.Id,
                book.ExpectedReturnDate
                ))
            );

        await _orderRepository.Add(order);

        return order;
    }
}
