using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soccer.Core.Specifications;
using Soccer.Infrastructure.Data;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.PlayerQueries
{
    public class PlayerQueriesHandler : 
        IRequestHandler<GetPlayerByIdQuery, PlayerViewModel?>,
        IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerSummaryViewModel>>,
        IRequestHandler<SearchPlayerByCnpQuery, PlayerSummaryViewModel?>
    {
        private readonly SoccerContext context;
        private readonly AutoMapper.IConfigurationProvider mapperConfiguration;

        public PlayerQueriesHandler(SoccerContext context, AutoMapper.IConfigurationProvider mapperConfiguration)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapperConfiguration = mapperConfiguration ?? throw new ArgumentNullException(nameof(mapperConfiguration));
        }
        public async Task<PlayerViewModel?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModel = await context.Players
                .WithSpecification(new PlayerByIdReadSpecification(request.Id))
                .ProjectTo<PlayerViewModel>(mapperConfiguration)
                .SingleOrDefaultAsync(cancellationToken);

            return viewModel;
        }

        public async Task<IEnumerable<PlayerSummaryViewModel>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModels = await context.Players
                .AsNoTracking()
                .ProjectTo<PlayerSummaryViewModel>(mapperConfiguration)
                .ToListAsync(cancellationToken);

            return viewModels ?? throw new InvalidOperationException();
        }

        public async Task<PlayerSummaryViewModel?> Handle(SearchPlayerByCnpQuery request,
            CancellationToken cancellationToken)
        {
            var viewModel = await context.Players
                .WithSpecification(new SearchPlayerByCnpSpecification(request.CNP))
                .ProjectTo<PlayerSummaryViewModel>(mapperConfiguration)
                .SingleOrDefaultAsync(cancellationToken: cancellationToken);

            return viewModel;
        }
    }
}
