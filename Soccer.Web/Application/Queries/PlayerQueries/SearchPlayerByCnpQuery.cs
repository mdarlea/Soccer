using MediatR;

using Soccer.Web.ViewModels;

namespace Soccer.Web.Application.Queries.PlayerQueries
{
    /// <summary>
    /// The query to search a player by CNP
    /// </summary>
    /// <remarks>
    /// The Player domain entity will be mapped to the PlayerSummary view model
    /// </remarks>
    public class SearchPlayerByCnpQuery : IRequest<PlayerSummaryViewModel?>
    {
        public string CNP { get; set; } = null!;
    }
}
