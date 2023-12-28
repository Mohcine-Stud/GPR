using GestionPretRetour.Application.Returns.Commands.ReturnOrderBook;
using GestionPretRetour.Domain.OrderAggregate.Entities;

namespace GestionPretRetour.Application.Returns.Services
{
    public interface IReturnOrderBooksService
    {
        Task<OrderBook> ReturnOrderBook(ReturnOrderBookCommand command);
    }
}