using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class OrderBookRepository : IOrderBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderBookRepository(ApplicationDbContext dbcontext)
    {
        _dbContext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
    }

    public async Task<OrderBook> GetById(Guid Id)
    {
        return await _dbContext.OrderBooks.FindAsync(Id);
    }

    public async Task Update(Guid id, OrderBook orderBook)
    {
        if (orderBook.Id == id)
        {
            var existingUser = await GetById(id);
            _dbContext.Entry(existingUser).CurrentValues.SetValues(orderBook);
            await _dbContext.SaveChangesAsync();
        }
    }
   
}
