using Ardalis.Specification;
using Soccer.Core.Entities.PlayerAggregate;

namespace Soccer.Core.Specifications
{
    /// <summary>
    /// Specification to search a player by CNP without the ability to change the player
    /// </summary>
    public sealed class SearchPlayerByCnpSpecification : SingleResultSpecification<Player>
    {
        public SearchPlayerByCnpSpecification(string cnp)
        {
            if (string.IsNullOrWhiteSpace(cnp)) throw new ArgumentNullException(nameof(cnp));

            Query.AsNoTracking().Search(c => c.CNP, cnp);
        }
    }
}
