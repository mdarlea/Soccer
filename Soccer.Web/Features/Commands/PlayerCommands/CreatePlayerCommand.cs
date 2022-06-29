using MediatR;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public class CreatePlayerCommand : BasePlayerCommand, IRequest<Guid>
    {
        public string CNP { get; set; } = null!;
    }
}
