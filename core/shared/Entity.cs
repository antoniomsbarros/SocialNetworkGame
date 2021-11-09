using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.core.shared
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity<TEntityId>
    where TEntityId : EntityId
    {
        [Key]
        public TEntityId Id { get; protected set; }
    }
}