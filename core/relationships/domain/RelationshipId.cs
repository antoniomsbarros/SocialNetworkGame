using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.relationships.domain
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
        protected override Object createFromString(String text)
        {
            return text;
        }

        public override String AsString()
        {
            return base.Value;
        }
    }
}