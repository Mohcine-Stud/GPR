using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.Users;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class OrderBookRepository : IOrderBookRepository
{
    private readonly ApplicationDbContext _Dbcontext;

    public OrderBookRepository(ApplicationDbContext dbcontext)
    {
        _Dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
    }

    public async Task<OrderBook> GetById(Guid Id)
    {
        return await _Dbcontext.OrderBooks.FindAsync(Id);
    }

    public async Task Update(Guid id, OrderBook orderBook)
    {
        if (orderBook.Id == id)
        {
            var existingUser = await GetById(id);
            _Dbcontext.Entry(existingUser).CurrentValues.SetValues(orderBook);
            await _Dbcontext.SaveChangesAsync();
        }
    }
}
