namespace Soccer.Core.Entities
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; protected set; }
    }
}
