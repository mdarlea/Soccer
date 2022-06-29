using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Interfaces;

namespace Soccer.Core.Entities.TeamAggregate
{
    public class Team : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        private readonly List<Player> players = new();
        public IEnumerable<Player> Players => players.AsReadOnly();

#pragma warning disable CS8618
        private Team()
#pragma warning restore CS8618
        {
            // required by EF
        }

        public Team(string name)
        {
            Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        }

        public void AddPlayer(Player player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            if (!Players.Any(p => p.Id == player.Id))
            {
                players.Add(player);
            }
        }
    }
}
