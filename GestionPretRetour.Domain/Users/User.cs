using GestionPretRetour.Domain.Users.ValueObjects;

namespace GestionPretRetour.Domain.Users;

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
        AttemptsNumber = 0;
    }

    public static User Create(Guid userId)
    {
        return new User(userId);
    }

    public void IncrementAttempts()
    {
        AttemptsNumber++;
    }

    public void AddPenalty(TimeSpan duration, string penaltyType)
    {
        var penalty = new Penalty
        {
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow + duration,
            PenaltyType = penaltyType
        };

        _penalties.Add(penalty);
    }

    public void LiftPenalty()
    {
        _penalties.RemoveAll(penalty => penalty.EndDate >= DateTime.UtcNow && penalty.StartDate <= DateTime.UtcNow);
    }

}
