using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Soccer.Core.Entities.GameAggregate;

namespace Soccer.Infrastructure.Data.Config
{
    public class GameTeamConfiguration : IEntityTypeConfiguration<GameTeam>
    {
        public void Configure(EntityTypeBuilder<GameTeam> builder)
        {
            builder.Property<Guid>("TeamId");
            builder.HasKey("TeamId", "GameId");
            builder.HasOne(gt => gt.Team).WithMany().HasForeignKey("TeamId");

        }
    }
}
