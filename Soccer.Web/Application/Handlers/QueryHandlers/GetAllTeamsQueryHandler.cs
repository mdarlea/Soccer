using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Soccer.Infrastructure.Data;
using Soccer.Web.Application.Queries.TeamQueries;
using Soccer.Web.ViewModels;

using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Soccer.Web.Application.Handlers.QueryHandlers
{
    public class GetAllTeamsQueryHandler
    : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamViewModel>>
    {
        private readonly SoccerContext context;
        private readonly IConfigurationProvider mapperConfiguration;

        public GetAllTeamsQueryHandler(SoccerContext context, IConfigurationProvider mapperConfiguration)
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
