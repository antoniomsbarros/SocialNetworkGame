using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.posts.domain.post
{
    public class PostId : EntityId
    {
        protected PostId() : base()
        {
        }

        public PostId(Guid guid) : base(guid)
        {
        }

        public PostId(String value) : base(value)
        {
        }
    }
}