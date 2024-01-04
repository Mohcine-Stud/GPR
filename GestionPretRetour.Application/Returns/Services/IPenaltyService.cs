using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;

namespace GestionPretRetour.Application.Returns.Services;

public interface IPenaltyService
{
    Task CalculPenalties(ReturnOrderBookCommand command);
}