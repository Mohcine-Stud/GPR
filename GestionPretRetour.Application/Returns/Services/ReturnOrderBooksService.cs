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
    private readonly IPenaltyRepository _penaltyRepository;

    public ReturnOrderBooksService(
        IUserRepository userRepository,
        IOrderBookRepository orderBookRepository,
        IOrderRepository orderRepository,
        IPenaltyRepository penaltyRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _orderBookRepository = orderBookRepository ?? throw new ArgumentNullException(nameof(orderBookRepository));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _penaltyRepository = penaltyRepository ?? throw new ArgumentNullException(nameof(penaltyRepository));
    }

    public async Task<OrderBook> ReturnOrderBook(ReturnOrderBookCommand command)
    {
        //check if the orderBook , user exist 
        var user = await _userRepository.GetById(command.UserId);
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
                    var activeUserPenaltie = user.Penalties
                        .Where(p => p.EndDate > DateTime.UtcNow)
                        .FirstOrDefault();
                    if(activeUserPenaltie == null)
                    {
                        var newPenalty = Penalty.Create(PenaltyType.WeekPenalty, user.Id);
                        await _penaltyRepository.Add(newPenalty);
                    }
                    else
                    {
                        var activePenaltyType = activeUserPenaltie.PenaltyType;
                        var newPenaltyType = activePenaltyType switch
                        {
                            PenaltyType.WeekPenalty => PenaltyType.YearPenalty,
                            PenaltyType.YearPenalty => PenaltyType.other,
                            _ => PenaltyType.other
                        };
                        var newPenalty = Penalty.Create(newPenaltyType, user.Id);
                        await _penaltyRepository.Add(newPenalty);
                    }
                }
                orderBook.AddActualReturnDate(DateTime.UtcNow);
                await _orderBookRepository.Update(command.OrderBookId, orderBook);
                return orderBook;
            }
        }
      
        return new OrderBook();
    }
}
