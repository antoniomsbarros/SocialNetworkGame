namespace SocialNetwork.core.model.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityId>
    {
        public TEntityId Id { get; protected init; }
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}