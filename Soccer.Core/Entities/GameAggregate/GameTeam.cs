using Soccer.Core.Entities.TeamAggregate;

namespace Soccer.Core.Entities.GameAggregate
{
    public class GameTeam
    {
        public Game Game { get; }
        public Team Team { get; }
        public int Score { get; internal set; }
        public bool? GameWon { get; internal set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GameTeam()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            // required for EF
        }

        internal GameTeam(Game game, Team team)
        {
            Game = game ?? throw new ArgumentNullException(nameof(game));
            Team = team ?? throw new ArgumentNullException(nameof(team));
        }
    }
}
