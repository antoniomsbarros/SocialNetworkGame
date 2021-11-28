using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.posts.domain.reaction
{
    public class ReactionId : EntityId
    {
        protected ReactionId() : base()
        {
        }

        public ReactionId(Guid guid) : base(guid)
        {
        }

        public ReactionId(String value) : base(value)
        {
        }
    }
}