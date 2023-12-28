using GestionPretRetour.Domain.OrderAggregate.Entities;

namespace GestionPretRetour.Domain.OrderAggregate;

public sealed class Order
{
    private readonly List<OrderBook> _books = new();

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public IReadOnlyList<OrderBook> Books => _books.AsReadOnly();
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public bool IsClosed { get; set; }

    public Order()
    {
    }
    private Order(Guid userId, List<OrderBook> books) : this()
    {
        Id = Guid.NewGuid();
        UserId = userId;
        _books = books;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }

    public static Order Create(Guid userId, List<OrderBook> books)
    {
        return new Order(userId, books);
    }

}
