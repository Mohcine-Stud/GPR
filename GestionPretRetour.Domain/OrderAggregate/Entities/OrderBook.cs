namespace GestionPretRetour.Domain.OrderAggregate.Entities;

public class OrderBook
{
    public Guid Id { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime? ActualReturnDate { get; private set; }
    public Guid OrderId { get; private set; }

    public OrderBook()
    {
    }

    private OrderBook(Guid id, DateTime expectedReturnDate) : this()
    {
        Id = id;
        ExpectedReturnDate = expectedReturnDate;
    }
    public static OrderBook Create(Guid id, DateTime expectedReturnDate)
    {
        return new OrderBook(id, expectedReturnDate);
    }
    public void AddActualReturnDate(DateTime date)
    {
        ActualReturnDate = date;
    }
    public bool IsReturnedAtExpectedDate(DateTime actualReturnDate)
    {
        return ExpectedReturnDate.Date== actualReturnDate.Date;
    }
}
