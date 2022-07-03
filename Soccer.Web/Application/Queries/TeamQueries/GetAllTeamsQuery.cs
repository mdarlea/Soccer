using MediatR;

using Soccer.Web.ViewModels;

namespace Soccer.Web.Application.Queries.TeamQueries
{
    /// <summary>
    /// The query to get all the teams
    /// </summary>
    /// <remarks>
    /// The Team domain entities will be mapped to the Team view model
    /// </remarks>
    public class GetAllTeamsQuery : IRequest<IEnumerable<TeamViewModel>>
    {
    }
}
