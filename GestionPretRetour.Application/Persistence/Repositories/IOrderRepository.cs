using GestionPretRetour.Domain.OrderAggregate;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IOrderRepository
{
    Task<Order> GetById(Guid id);
    Task Add(Order order);


}
