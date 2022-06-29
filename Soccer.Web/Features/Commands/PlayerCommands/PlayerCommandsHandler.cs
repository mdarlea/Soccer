using FluentValidation;
using MediatR;
using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Entities.TeamAggregate;
using Soccer.Core.Interfaces;

namespace Soccer.Web.Features.Commands.PlayerCommands
{
    public class PlayerCommandsHandler : 
        IRequestHandler<CreatePlayerCommand, Guid>,
        IRequestHandler<UpdatePlayerCommand, Guid>
    {
        private readonly IRepository<Player> playerRepository;
        private readonly IReadRepository<Team> teamRepository;

        public PlayerCommandsHandler(
            IRepository<Player> playerRepository, 
            IReadRepository<Team> teamRepository)
        {
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.teamRepository = teamRepository;
        }

        public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var team = await teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
            if (team == null)
            {
                throw new ValidationException($"Cannot find team for Id={request.TeamId}");
            }

            var address = new Address(request.StreetAddress, request.City, request.Country, request.PostalCode);

            var player = new Player(
                team,
                request.FirstName,
                request.LastName,
                address,
                request.Position,
                request.CNP);

            await playerRepository.AddAsync(player, cancellationToken);

            await playerRepository.SaveChangesAsync(cancellationToken);

            return player.Id;
        }

        public async Task<Guid> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var team = await teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
            if (team == null)
            {
                throw new ValidationException($"Cannot find team for Id={request.TeamId}");
            }

            var player = await playerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (player == null)
            {
                throw new ValidationException($"Cannot find player for Id={request.Id}");
            }

            player.Address = new Address(request.StreetAddress, request.City, request.Country, request.PostalCode);
            player.Team = team;
            player.FirstName = request.FirstName;
            player.LastName = request.LastName;
            player.Position = request.Position;

            await playerRepository.UpdateAsync(player, cancellationToken);

            await playerRepository.SaveChangesAsync(cancellationToken);

            return player.Id;
        }
    }
}
