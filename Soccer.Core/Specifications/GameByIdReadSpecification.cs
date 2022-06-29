using Ardalis.Specification;
using Soccer.Core.Entities.GameAggregate;

namespace Soccer.Core.Specifications
{
    public sealed class GameByIdReadSpecification : SingleResultSpecification<Game>
    {
        public GameByIdReadSpecification(Guid id)
        {
            Query.AsNoTracking().Where(game => game.Id == id);
        }
    }
}
