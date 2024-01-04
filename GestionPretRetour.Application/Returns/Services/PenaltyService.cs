using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using GestionPretRetour.Domain.UserAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Enums;

namespace GestionPretRetour.Application.Returns.Services;

public class PenaltyService : IPenaltyService
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderBookRepository _orderBookRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IPenaltyRepository _penaltyRepository;

    public PenaltyService(
        IUserRepository userRepository, 
        IOrderBookRepository orderBookRepository, 
        IOrderRepository orderRepository, 
        IPenaltyRepository penaltyRepository)
    {
        _userRepository = userRepository;
        _orderBookRepository = orderBookRepository;
        _orderRepository = orderRepository;
        _penaltyRepository = penaltyRepository;
    }

    public async Task CalculPenalties(ReturnOrderBookCommand command)
    {
        var user = await _userRepository.GetById(command.UserId);
        var activeUserPenaltie = user.Penalties
        .Where(p => p.EndDate > DateTime.UtcNow)
                        .FirstOrDefault();
        if (activeUserPenaltie == null)
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
}


