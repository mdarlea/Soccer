using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soccer.Core.Entities.TeamAggregate;

namespace Soccer.Infrastructure.Data.Config
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Team.Players));
            navigation!.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
