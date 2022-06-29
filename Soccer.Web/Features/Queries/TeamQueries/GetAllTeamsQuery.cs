using MediatR;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.TeamQueries
{
    public class GetAllTeamsQuery : IRequest<IEnumerable<TeamViewModel>>
    {
    }
}
