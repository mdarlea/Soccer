using MediatR;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.PlayerQueries
{
    public class GetAllPlayersQuery: IRequest<IEnumerable<PlayerSummaryViewModel>>
    {
    }
}
