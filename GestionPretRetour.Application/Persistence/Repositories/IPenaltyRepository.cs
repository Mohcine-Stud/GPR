using GestionPretRetour.Domain.UserAggregate.Entities;

namespace GestionPretRetour.Application.Persistence.Repositories;

public interface IPenaltyRepository
{
    Task Add(Penalty penalty);
}
