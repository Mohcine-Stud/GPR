using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Domain.Users;

namespace GestionPretRetour.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _Dbcontext;
    public UserRepository(ApplicationDbContext dbcontext)
    {
        _Dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
    }

    public async Task Add(User user)
    {
        await _Dbcontext.Users.AddAsync(user);
        await _Dbcontext.SaveChangesAsync();
    }

    public async Task<User> GetById(Guid Id)
    {
        return await _Dbcontext.Users.FindAsync(Id);
    }

    public async Task Update(Guid Id, User user)
    {
        if(user.Id == Id)
        {
            var existingUser = await GetById(Id);
            _Dbcontext.Entry(existingUser).CurrentValues.SetValues(user);
            await _Dbcontext.SaveChangesAsync();
        }
    }
}
