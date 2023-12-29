using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using GestionPretRetour.Domain.OrderAggregate.Entities;

namespace GestionPretRetour.Application.Returns.Services;

public class ReturnOrderBooksService : IReturnOrderBooksService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderBookRepository _orderBookRepository;
    private readonly IOrderRepository _orderRepository;

    public ReturnOrderBooksService(
        IUserRepository userRepository,
        IOrderBookRepository orderBookRepository,
        IOrderRepository orderRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _orderBookRepository = orderBookRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
    }

    public async Task<OrderBook> ReturnOrderBook(ReturnOrderBookCommand command)
    {
        //check if the orderBook exist 
        var orderBook = await _orderBookRepository.GetById(command.OrderBookId);
        if (orderBook != null)
        {
            //get the order that contains the book
            var order = await _orderRepository.GetById(orderBook.OrderId);

            //check if the commandUser is the one who took this book
            if (order.UserId == command.UserId)
            {
                orderBook.AddActualReturnDate(DateTime.UtcNow);
                await _orderBookRepository.Update(command.OrderBookId, orderBook);
                return orderBook;
            }
        }
      
        return null;
    }
}
