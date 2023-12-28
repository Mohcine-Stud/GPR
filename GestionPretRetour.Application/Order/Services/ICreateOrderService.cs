using GestionPretRetour.Application.Orders.Commands.CreateOrder;
using GestionPretRetour.Domain.OrderAggregate;

namespace GestionPretRetour.Application.Orders.Services
{
    public interface ICreateOrderService
    {
        Task<Order> CreateOrder(CreateOrderCommand command);
    }
}