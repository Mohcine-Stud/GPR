using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using GestionPretRetour.Domain.OrderAggregate.Entities;

namespace GestionPretRetour.Application.Returns.Services;

public class ReturnOrderBooksService : IReturnOrderBooksService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderBookRepository _orderBookRepository;

    public ReturnOrderBooksService(
        IUserRepository userRepository,
        IOrderBookRepository orderBookRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _orderBookRepository = orderBookRepository ?? throw new ArgumentNullException(nameof(userRepository)); ;
    }

    public async Task<OrderBook> ReturnOrderBook(ReturnOrderBookCommand command)
    {
        var orderUser = await _userRepository.GetById(command.UserId);
        if (orderUser == null)
        {
            var orderBook = await _orderBookRepository.GetById(command.OrderBookId);
            if (orderBook != null)
            {
                orderBook.AddActualReturnDate(DateTime.UtcNow);
                await _orderBookRepository.Update(command.OrderBookId, orderBook);
                return orderBook;
            }
        }
        return null;
    }
}
