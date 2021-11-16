namespace SocialNetwork.core.model.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityId>
    {
        public TEntityId Id { get; protected set; }
        public override abstract bool Equals(object obj);
        public override abstract int GetHashCode();
    }
}