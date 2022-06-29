using MediatR;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public class UpdatePlayerCommand: BasePlayerCommand, IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
