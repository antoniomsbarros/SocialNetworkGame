using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.tags.domain
{
    public class TagId : EntityId
    {
        protected TagId()
        {
        }

        public TagId(Guid guid) : base(guid)
        {
        }

        public TagId(String value) : base(value)
        {
        }
    }
}