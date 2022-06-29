using Microsoft.EntityFrameworkCore;

using Soccer.Core.Entities.GameAggregate;
using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Entities.TeamAggregate;

namespace Soccer.Infrastructure.Data
{
    public class SoccerContext : DbContext
    {
#pragma warning disable CS8618
        public SoccerContext(DbContextOptions<SoccerContext> options) : base(options)
#pragma warning restore CS8618
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameTeam> GameTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
