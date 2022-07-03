using MediatR;

namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Command to create a player
    /// </summary>
    /// <remrks>
    /// The command's handler will return the id of the newly created player
    /// </remrks>    
    public class CreatePlayerCommand : BasePlayerCommand, IRequest<Guid>
    {
        /// <summary>
        /// The player's CNP
        /// </summary>
        public string CNP { get; set; } = null!;
    }
}
