using MediatR;

namespace Soccer.Web.Application.Commands.PlayerCommands
{
    /// <summary>
    /// Command to update a player
    /// </summary>
    /// <remrks>
    /// The command's handler will return the id of the updated player
    /// </remrks>    
    public class UpdatePlayerCommand : BasePlayerCommand, IRequest<Guid>
    {
        /// <summary>
        /// The player's id
        /// </summary>
        public Guid Id { get; set; }
    }
}
