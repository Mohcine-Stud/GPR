using GestionPretRetour.Domain.Users;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid Id);
    Task Add(User user);
    Task Update(Guid Id, User user);
}
