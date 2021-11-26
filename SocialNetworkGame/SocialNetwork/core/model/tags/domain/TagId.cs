using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.tags.domain
{
    public class TagId : EntityId
    {
        protected TagId() : base()
        {
        }

        public TagId(Guid guid) : base(guid)
        {
        }

        public TagId(String value) : base(value)
        {
        }

        protected override Object createFromString(String text)
        {
            return text;
        }

        public override String AsString()
        {
            return Value;
        }
    }
}