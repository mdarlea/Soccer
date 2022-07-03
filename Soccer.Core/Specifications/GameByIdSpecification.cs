using Ardalis.Specification;
using Soccer.Core.Entities.GameAggregate;

namespace Soccer.Core.Specifications
{
    /// <summary>
    /// Get a game by Id for update.
    /// The information about the game score (GameTeams asociation) and the participating teams (Team association) will be loaded
    /// </summary>
    public sealed class GameByIdSpecification : SingleResultSpecification<Game>
    {
        public GameByIdSpecification(Guid id)
        {
            Query.Include(g => g.GameTeams).ThenInclude(gt => gt.Team).Where(game => game.Id == id);
        }
    }
}
