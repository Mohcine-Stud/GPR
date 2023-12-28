namespace GestionPretRetour.Domain.Users.ValueObjects;

public class Penalty
{
    public int Id { get; private set; }
    public string PenaltyType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}
