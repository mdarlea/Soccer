namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public abstract class BasePlayerCommand
    {
        public Guid TeamId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Position { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
