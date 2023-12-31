using GestionPretRetour.Domain.OrderAggregate;
using GestionPretRetour.Domain.OrderAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPretRetour.Infrastructure.Persistence.Configurations
{
    public class OrderBookConfigurations : IEntityTypeConfiguration<OrderBook>
    {
        public void Configure(EntityTypeBuilder<OrderBook> builder)
        {
            builder.ToTable("OrderBooks");
            builder.HasKey(ob => ob.Id);
            builder.Property(ob => ob.Id).ValueGeneratedNever();

            builder.HasOne<Order>()
                .WithMany(o => o.Books)
                .HasForeignKey(ob => ob.OrderId);
        }
    }
}
