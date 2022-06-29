using Ardalis.Specification.EntityFrameworkCore;
using Soccer.Core.Interfaces;

namespace Soccer.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(SoccerContext dbContext) : base(dbContext)
        {
        }
    }
}
