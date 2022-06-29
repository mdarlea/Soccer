using MediatR;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Features.Queries.PlayerQueries
{
    public class SearchPlayerByCnpQuery: IRequest<PlayerSummaryViewModel?>
    {
        public string CNP { get; set; } = null!;
    }
}
