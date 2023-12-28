using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _Dbcontext;

    public OrderRepository(ApplicationDbContext dbcontext)
    {
        _Dbcontext = dbcontext;
    }

    public async Task Add(Order order)
    {
        await _Dbcontext.AddAsync(order);
        await _Dbcontext.SaveChangesAsync();
    }
}
