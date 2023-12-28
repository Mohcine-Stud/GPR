using GestionPretRetour.Domain.OrderAggregate;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IOrderRepository
{
    Task Add(Order order); 
}
