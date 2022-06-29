using MediatR;

namespace Soccer.Web.Features.Commands.GameCommands
{
    public class CreateGameCommand: BaseGameCommand, IRequest<Guid>
    {
        public DateTimeOffset DateAndTime { get; set; }
        
    }
}
