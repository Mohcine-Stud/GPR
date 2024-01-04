using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Enums;

namespace GestionPretRetour.Application.Returns.Services;

public class ReturnOrderBooksService : IReturnOrderBooksService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderBookRepository _orderBookRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IPenaltyService _penaltyService;
    public ReturnOrderBooksService(
        IUserRepository userRepository,
        IOrderBookRepository orderBookRepository,
        IOrderRepository orderRepository,
        IPenaltyService penaltyService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _orderBookRepository = orderBookRepository ?? throw new ArgumentNullException(nameof(orderBookRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _penaltyService = penaltyService;
    }

    public async Task<OrderBook> ReturnOrderBook(ReturnOrderBookCommand command)
    {
       
        //check if the orderBook , user exist 
        var orderBook = await _orderBookRepository.GetById(command.OrderBookId);
        if (orderBook != null)
        {
            //get the order that contains the book
            var order = await _orderRepository.GetById(orderBook.OrderId);

            //check if the commandUser is the one who took this book
            if (order.UserId == command.UserId)
            {
                //penalty calcul ( need to be in a separate PenaltiesService file !!)
                if (!orderBook.IsReturnedAtExpectedDate(DateTime.UtcNow))
                {
                    await _penaltyService.CalculPenalties(command);
                }
                orderBook.AddActualReturnDate(DateTime.UtcNow);
                await _orderBookRepository.Update(command.OrderBookId, orderBook);
                return orderBook;
            }
        }
      
        return new OrderBook();
    }
}
