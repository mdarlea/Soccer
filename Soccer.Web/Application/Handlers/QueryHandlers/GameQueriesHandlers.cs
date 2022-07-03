using Ardalis.Specification.EntityFrameworkCore;

using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Soccer.Core.Specifications;
using Soccer.Infrastructure.Data;
using Soccer.Web.Application.Queries.GameQueries;
using Soccer.Web.Application.Responses;
using Soccer.Web.ViewModels;

using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Soccer.Web.Application.Handlers.QueryHandlers
{
    /// <summary>
    /// The game query handlers
    /// </summary>
    /// <remarks>
    /// The following queries will be handled:
    /// <para>Get all games</para>
    /// <para>Get a game by id</para>
    /// </remarks>
    public class GameQueriesHandlers :
        IRequestHandler<GetAllGamesQuery, IEnumerable<GameSummaryViewModel>>,
        IRequestHandler<GetGameByIdQuery, GameResponse?>

    {
        private readonly SoccerContext context;
        private readonly IConfigurationProvider mapperConfiguration;

        public GameQueriesHandlers(SoccerContext context, IConfigurationProvider mapperConfiguration)
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

        public async Task<GameResponse?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModel = await context.Games
                .WithSpecification(new GameByIdReadSpecification(request.Id))
                .ProjectTo<GameResponse>(mapperConfiguration)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }
    }
}
