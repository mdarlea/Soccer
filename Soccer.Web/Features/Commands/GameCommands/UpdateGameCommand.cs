using MediatR;

namespace Soccer.Web.Features.Commands.GameCommands
{
    public class UpdateGameCommand: BaseGameCommand, IRequest<Guid>
    {
        public Guid GameId { get; set; }
    }
}
