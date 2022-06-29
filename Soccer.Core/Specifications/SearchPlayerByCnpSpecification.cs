using Ardalis.Specification;
using Soccer.Core.Entities.PlayerAggregate;

namespace Soccer.Core.Specifications
{
    public sealed class SearchPlayerByCnpSpecification : SingleResultSpecification<Player>
    {
        public SearchPlayerByCnpSpecification(string cnp)
        {
            if (string.IsNullOrWhiteSpace(cnp)) throw new ArgumentNullException(nameof(cnp));

            Query.AsNoTracking().Search(c => c.CNP, cnp);
        }
    }
}
