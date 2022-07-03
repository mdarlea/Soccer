using MediatR;

namespace Soccer.Web.Application.Commands.GameCommands
{
    /// <summary>
    /// Command to create a game
    /// </summary>
    /// <remrks>
    /// The command's handler will return the id of the newly created game
    /// </remrks>
    public class CreateGameCommand : BaseGameCommand, IRequest<Guid>
    {
        /// <summary>
        /// The date and time of the game
        /// </summary>
        public DateTimeOffset DateAndTime { get; set; }

    }
}
