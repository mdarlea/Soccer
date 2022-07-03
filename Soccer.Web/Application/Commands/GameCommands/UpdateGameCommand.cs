using MediatR;

namespace Soccer.Web.Application.Commands.GameCommands
{
    /// <summary>
    /// Command to update a game
    /// </summary>
    /// <remrks>
    /// The command's handler will return the id of the updated game
    /// </remrks>
    public class UpdateGameCommand : BaseGameCommand, IRequest<Guid>
    {
        /// <summary>
        /// The Game Id
        /// </summary>
        public Guid GameId { get; set; }
    }
}
