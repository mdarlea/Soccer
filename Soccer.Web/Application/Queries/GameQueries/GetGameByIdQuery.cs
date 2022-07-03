using MediatR;

using Soccer.Web.Application.Responses;

namespace Soccer.Web.Application.Queries.GameQueries
{
    /// <summary>
    /// The query to get a game by id
    /// </summary>
    /// <remarks>
    /// The game domain entity will be mapped to the GameResponse DTO
    /// </remarks>
    public class GetGameByIdQuery : IRequest<GameResponse?>
    {
        /// <summary>
        /// The game Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
