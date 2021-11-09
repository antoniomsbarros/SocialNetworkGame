using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.core.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityId>
    where TEntityId : EntityId
    {
        public TEntityId Id { get; protected set; }
    }
}