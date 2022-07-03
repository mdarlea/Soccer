using Microsoft.EntityFrameworkCore;

using Soccer.Core.Entities.GameAggregate;
using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Entities.TeamAggregate;

namespace Soccer.Infrastructure.Data
{
    /// <summary>
    /// The Soccer database context
    /// </summary>
    public class SoccerContext : DbContext
    {
#pragma warning disable CS8618
        public SoccerContext(DbContextOptions<SoccerContext> options) : base(options)
#pragma warning restore CS8618
        {

        }

        /// <summary>
        /// The game entities
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// A relationship of many to many to keep track of the score for each team participating in the game
        /// </summary>
        public DbSet<GameTeam> GameTeams { get; set; }

        /// <summary>
        /// The player entities
        /// </summary>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// The team entities
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
