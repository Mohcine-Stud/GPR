using GestionPretRetour.Domain.UserAggregate.Enums;

namespace GestionPretRetour.Domain.UserAggregate.Entities;

public class Penalty
{
    public Guid Id { get; private set; }
    public PenaltyType PenaltyType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }

}
