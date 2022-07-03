using MediatR;

using Soccer.Web.ViewModels;

namespace Soccer.Web.Application.Queries.PlayerQueries
{
    /// <summary>
    /// The query to get all the players
    /// </summary>
    /// <remarks>
    /// The Player domain entities will be mapped to the PlayerSummary view model
    /// </remarks>
    public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerSummaryViewModel>>
    {
    }
}
