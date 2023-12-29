using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }

    public async Task Add(Order order)
    {
        await _dbContext.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _dbContext.Orders.ToListAsync();
    }
    public async Task<Order> GetById(Guid id)
    {
        return await _dbContext.Orders.FindAsync(id);
    }

}
