using MediatR;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.GameQueries
{
    public class GetAllGamesQuery: IRequest<IEnumerable<GameSummaryViewModel>>
    {
    }
}
