using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soccer.Core.Specifications;
using Soccer.Infrastructure.Data;
using Soccer.Web.Models;
using Soccer.Web.ViewModels;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Soccer.Web.Features.Queries.GameQueries
{
    public class GameQueriesHandler:
        IRequestHandler<GetAllGamesQuery, IEnumerable<GameSummaryViewModel>>,
        IRequestHandler<GetGameByIdQuery, GameModel?>

    {
        private readonly SoccerContext context;
        private readonly IConfigurationProvider mapperConfiguration;

        public GameQueriesHandler(SoccerContext context, IConfigurationProvider mapperConfiguration)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapperConfiguration = mapperConfiguration ?? throw new ArgumentNullException(nameof(mapperConfiguration));
        }

        public async Task<IEnumerable<GameSummaryViewModel>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModels = await context.Games
                .AsNoTracking()
                .ProjectTo<GameSummaryViewModel>(mapperConfiguration)
                .ToListAsync(cancellationToken: cancellationToken);

            return viewModels ?? throw new InvalidOperationException();
        }

        public async Task<GameModel?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModel = await context.Games
                .WithSpecification(new GameByIdReadSpecification(request.Id))
                .ProjectTo<GameModel>(mapperConfiguration)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }
    }
}
