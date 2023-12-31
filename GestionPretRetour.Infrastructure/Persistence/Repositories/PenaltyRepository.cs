using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Entities;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class PenaltyRepository : IPenaltyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PenaltyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Penalty penalty)
    {
        await _dbContext.UserPenalties.AddAsync(penalty);
        await _dbContext.SaveChangesAsync();
    }

}
