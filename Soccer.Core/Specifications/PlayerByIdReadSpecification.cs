using Ardalis.Specification;
using Soccer.Core.Entities.PlayerAggregate;

namespace Soccer.Core.Specifications
{
    public sealed class PlayerByIdReadSpecification: SingleResultSpecification<Player>
    {
        public PlayerByIdReadSpecification(Guid id)
        {
            Query.AsNoTracking().Where(p => p.Id == id);
        }
    }
}
