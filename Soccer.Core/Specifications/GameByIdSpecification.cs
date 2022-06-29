using Ardalis.Specification;
using Soccer.Core.Entities.GameAggregate;

namespace Soccer.Core.Specifications
{
    public sealed class GameByIdSpecification : SingleResultSpecification<Game>
    {
        public GameByIdSpecification(Guid id)
        {
            Query.Include(g => g.GameTeams).ThenInclude(gt => gt.Team).Where(game => game.Id == id);
        }
    }
}
