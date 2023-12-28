using GestionPretRetour.Domain.OrderAggregate.Entities;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IOrderBookRepository
{
    Task<OrderBook> GetById(Guid id);
    Task Update(Guid id, OrderBook orderBook);
}
