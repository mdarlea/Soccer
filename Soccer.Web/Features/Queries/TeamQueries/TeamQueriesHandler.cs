using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Soccer.Infrastructure.Data;
using Soccer.Web.ViewModels;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Soccer.Web.Features.Queries.TeamQueries
{
    public class TeamQueriesHandler
    : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamViewModel>>
    {
        private readonly SoccerContext context;
        private readonly IConfigurationProvider mapperConfiguration;

        public TeamQueriesHandler(SoccerContext context, AutoMapper.IConfigurationProvider mapperConfiguration)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapperConfiguration = mapperConfiguration ?? throw new ArgumentNullException(nameof(mapperConfiguration));
        }

        public async Task<IEnumerable<TeamViewModel>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var viewModels = await context.Teams
                .AsNoTracking()
                .ProjectTo<TeamViewModel>(mapperConfiguration)
                .ToListAsync(cancellationToken: cancellationToken);

            return viewModels ?? throw new InvalidOperationException();
        }
    }
}
