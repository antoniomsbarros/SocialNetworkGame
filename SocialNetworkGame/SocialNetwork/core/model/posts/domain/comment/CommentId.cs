using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.posts.domain.comment
{
    public class CommentId : EntityId
    {
        protected CommentId() : base()
        {
        }

        public CommentId(Guid guid) : base(guid)
        {
        }

        public CommentId(String value) : base(value)
        {
        }
    }
}