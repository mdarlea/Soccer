using Ardalis.Specification;
using Soccer.Core.Entities.PlayerAggregate;

namespace Soccer.Core.Specifications
{
    /// <summary>
    /// Get a player by Id in read mode
    /// </summary>
    public sealed class PlayerByIdReadSpecification: SingleResultSpecification<Player>
    {
        public PlayerByIdReadSpecification(Guid id)
        {
            Query.AsNoTracking().Where(p => p.Id == id);
        }
    }
}
