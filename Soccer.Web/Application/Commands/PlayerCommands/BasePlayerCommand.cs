namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Properties common to CreatePlayerCommand and UpdatePlayerCommand
    /// </summary>
    public abstract class BasePlayerCommand
    {
        /// <summary>
        /// Player's team id
        /// </summary>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Player's first name
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Player's last name
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Player's position
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Player's street address
        /// </summary>
        public string StreetAddress { get; set; } = null!;

        /// <summary>
        /// Player's city
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Player''s postal code
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Player's country
        /// </summary>
        public string? Country { get; set; }
    }
}
