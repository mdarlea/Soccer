﻿using Ardalis.Specification.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soccer.Core.Entities.GameAggregate;
using Soccer.Core.Entities.TeamAggregate;
using Soccer.Core.Interfaces;
using Soccer.Core.Specifications;
using Soccer.Infrastructure.Data;

namespace Soccer.Web.Features.Commands.GameCommands
{
    public class GameCommandsHandler : 
        IRequestHandler<CreateGameCommand, Guid>,
        IRequestHandler<UpdateGameCommand, Guid>
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IReadRepository<Team> teamRepository;

        public GameCommandsHandler(
            IRepository<Game> gameRepository,
            IReadRepository<Team> teamRepository)
        {
            this.gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            this.teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game(request.DateAndTime);

            foreach (var teamScore in request.TeamScores)
            {
                var team = await teamRepository.GetByIdAsync(teamScore.TeamId, cancellationToken);

                if (team == null)
                {
                    throw new ValidationException($"Cannot find team for Id={teamScore.TeamId}");
                }

                game.AddScore(team, teamScore.Score);
            }

            if (request.IsFinalScore)
            {
                game.SetFinalScore();
            }

            await gameRepository.AddAsync(game, cancellationToken);

            await gameRepository.SaveChangesAsync(cancellationToken);

            return game.Id;
        }


        public async Task<Guid> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var spec = new GameByIdSpecification(request.GameId);
            
            var game = await gameRepository.SingleOrDefaultAsync(spec, cancellationToken);
            if (game == null)
            {
                throw new ValidationException($"Cannot find game for Id={request.GameId}");
            }

            foreach (var teamScore in request.TeamScores)
            {
                var team = game.Teams.SingleOrDefault(t => t.Id == teamScore.TeamId);

                if (team == null)
                {
                    throw new ValidationException($"Cannot find team for Id={teamScore.TeamId}");
                }

                game.AddScore(team, teamScore.Score);
            }

            if (request.IsFinalScore)
            {
                game.SetFinalScore();
            }

            await gameRepository.UpdateAsync(game, cancellationToken);

            await gameRepository.SaveChangesAsync(cancellationToken);

            return game.Id;
        }
    }
}