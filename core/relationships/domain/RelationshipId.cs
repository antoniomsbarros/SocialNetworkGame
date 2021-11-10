using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.relationships.domain
{
    [Owned]
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