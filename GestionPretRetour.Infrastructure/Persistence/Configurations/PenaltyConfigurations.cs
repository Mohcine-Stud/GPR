using GestionPretRetour.Domain.UserAggregate;
using GestionPretRetour.Domain.UserAggregate.Entities;
using GestionPretRetour.Domain.UserAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPretRetour.Infrastructure.Persistence.Configurations;

public class PenaltyConfigurations : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.ToTable("UserPenalties");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.PenaltyType)
            .HasConversion(
                c => c.ToString(),
                c => Enum.Parse<PenaltyType>(c));

        builder.HasOne<User>()
            .WithMany(u => u.Penalties)
            .HasForeignKey(p => p.UserId);
    }
}
