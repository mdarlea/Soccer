using Soccer.Core.Entities.TeamAggregate;
using Soccer.Core.Interfaces;

namespace Soccer.Core.Entities.PlayerAggregate
{
    public class Player: EntityBase, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; }
        public string? Position { get; set; }
        public Address Address { get; set; }
        public Team Team { get; set; }


#pragma warning disable CS8618
        private Player()
#pragma warning restore CS8618
        {
            // required for EF
        }

        public Player(Team team, string firstName, string lastName, Address address, string? position, string cnp)
        {
            Team = team ?? throw new ArgumentNullException(nameof(team));
            FirstName = string.IsNullOrWhiteSpace(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = string.IsNullOrWhiteSpace(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Position = position;
            CNP = string.IsNullOrWhiteSpace(cnp) ? throw new ArgumentNullException(nameof(cnp)) : cnp;
        }
    }
}
