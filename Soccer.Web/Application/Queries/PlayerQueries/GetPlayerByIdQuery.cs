using MediatR;

using Soccer.Web.ViewModels;

namespace Soccer.Web.Application.Queries.PlayerQueries
{
    /// <summary>
    /// The query to get a player by id
    /// </summary>
    /// <remarks>
    /// The Player domain entity will be mapped to the Player view model
    /// </remarks>
    public class GetPlayerByIdQuery : IRequest<PlayerViewModel?>
    {
        public Guid Id { get; set; }
    }
}
