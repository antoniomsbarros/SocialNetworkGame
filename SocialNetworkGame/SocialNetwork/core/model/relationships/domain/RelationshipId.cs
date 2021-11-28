using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.relationships.domain
{
    public class RelationshipId : EntityId
    {
        protected RelationshipId() : base()
        {
        }

        public RelationshipId(Guid guid) : base(guid)
        {
        }

        public RelationshipId(String value) : base(value)
        {
        }
    }
}