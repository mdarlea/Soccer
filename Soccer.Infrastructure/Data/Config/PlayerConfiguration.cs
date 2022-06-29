using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soccer.Core.Entities.PlayerAggregate;

namespace Soccer.Infrastructure.Data.Config
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.CNP).HasMaxLength(100).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(100).IsRequired();

            builder.OwnsOne(b => b.Address, sb =>
            {
                sb.Property(x => x.City).IsRequired().HasMaxLength(100);
                sb.Property(x => x.Street).IsRequired().HasMaxLength(255);
                sb.Property(x => x.PostalCode).HasMaxLength(50);
                sb.Property(x => x.Country).HasMaxLength(100);
            });
        }
    }
}
