using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soccer.Core.Entities.GameAggregate;

namespace Soccer.Infrastructure.Data.Config
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            var scoresNavigation = builder.Metadata.FindNavigation(nameof(Game.GameTeams));
            scoresNavigation!.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(x => x.Teams);
        }
    }
}
