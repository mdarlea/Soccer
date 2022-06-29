using MediatR;
using Soccer.Web.Models;

namespace Soccer.Web.Features.Queries.GameQueries
{
    public class GetGameByIdQuery: IRequest<GameModel?>
    {
        public Guid Id { get; set; }
    }
}
