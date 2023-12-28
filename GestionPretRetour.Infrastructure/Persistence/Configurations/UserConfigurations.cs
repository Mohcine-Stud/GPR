using GestionPretRetour.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionPretRetour.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
        ConfigurePenaltyTable(builder);
    }

    private void ConfigurePenaltyTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(u => u.Penalties, pb =>
        {
            pb.ToTable("UserPenalties");
            pb.HasKey(p => p.Id);
            pb.WithOwner().HasForeignKey("UserId");
        });
        builder.Metadata.FindNavigation(nameof(User.Penalties))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedNever();
    }
}
