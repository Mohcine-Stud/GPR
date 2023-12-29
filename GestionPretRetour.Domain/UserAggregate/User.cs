using GestionPretRetour.Domain.UserAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Enums;

namespace GestionPretRetour.Domain.UserAggregate;

public sealed class User
{
    private readonly List<Penalty> _penalties = new();
    public Guid Id { get; private set; }
    public int AttemptsNumber { get; private set; }
    public IReadOnlyList<Penalty> Penalties => _penalties.AsReadOnly();
    public User() { }
    private User(Guid userId)
    {
        Id = userId;
        AttemptsNumber = 1;
    }

    public static User Create(Guid userId)
    {
        return new User(userId);
    }

    public void IncrementAttempts()
    {
        AttemptsNumber++;
    }

    


}
