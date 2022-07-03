using MediatR;

using Soccer.Web.ViewModels;

namespace Soccer.Web.Application.Queries.GameQueries
{
    /// <summary>
    /// The query to get all the games
    /// </summary>
    /// <remarks>
    /// The game domain entities will be mapped to the GameSummary view model
    /// </remarks>
    public class GetAllGamesQuery : IRequest<IEnumerable<GameSummaryViewModel>>
    {
    }
}
