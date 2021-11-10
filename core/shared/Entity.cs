namespace SocialNetwork.core.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityId>
    where TEntityId : EntityId
    {
        public TEntityId Id { get; protected set; }
        public override abstract bool Equals(object obj);
        public override abstract int GetHashCode();
    }
}