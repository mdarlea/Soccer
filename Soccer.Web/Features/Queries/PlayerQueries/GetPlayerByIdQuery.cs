using MediatR;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.PlayerQueries
{
    public class GetPlayerByIdQuery : IRequest<PlayerViewModel?>
    {
        public Guid Id { get; set; }
    }
}
