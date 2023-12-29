using GestionPretRetour.Domain.OrderAggregate;
using GestionPretRetour.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPretRetour.Infrastructure.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrderTable(builder);
        ConfigureOrderBookTable(builder);
    }

    private void ConfigureOrderBookTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(o => o.Books, booksBuilder =>
        {
            booksBuilder.ToTable("OrderBooks");
            booksBuilder.WithOwner().HasForeignKey(b => b.OrderId);
            booksBuilder.HasKey("Id");
            booksBuilder.Property(b => b.Id).ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Order.Books))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .ValueGeneratedNever();
    }
}
