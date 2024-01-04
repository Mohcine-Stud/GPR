using GestionPretRetour.Domain.UserAggregate.Enums;

namespace GestionPretRetour.Domain.UserAggregate.Entities;

public class Penalty
{
    public Guid Id { get; private set; }
    public PenaltyType PenaltyType { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool Status { get; private set; }
    public Guid UserId { get; private set; }
    public Penalty()
    {
    }
    private Penalty( PenaltyType type, DateTime startAt, DateTime endAt, Guid userId)
    {
        Id = Guid.NewGuid();
        PenaltyType = type;
        StartDate = startAt;
        EndDate = endAt;
        UserId = userId;
    }
    public static Penalty Create(PenaltyType type, Guid userId)
    {
        DateTime startAt = DateTime.Now;
        DateTime endAt = type switch
        {
            PenaltyType.WeekPenalty => DateTime.UtcNow.AddDays(7),
            PenaltyType.YearPenalty => DateTime.UtcNow.AddDays(365),
            _ => DateTime.UtcNow
        };

        return new Penalty(type, startAt, endAt, userId);
    }   
}

