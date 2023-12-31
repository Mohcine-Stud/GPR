using GestionPretRetour.Domain.UserAggregate;
using GestionPretRetour.Domain.UserAggregate.Entities;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid Id);
    Task Add(User user);
    Task Update(Guid Id, User user);
}
