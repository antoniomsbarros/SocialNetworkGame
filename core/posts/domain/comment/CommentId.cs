using System;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.comment
{
    public class CommentId : EntityId
    {
        public CommentId(Guid value) : base(value)
        {
        }

        public CommentId(String value) : base(value)
        {
        }

        override
        protected Object createFromString(String text)
        {
            return new Guid(text);
        }

        override
        public String AsString()
        {
            Guid obj = (Guid)base.ObjValue;
            return obj.ToString();
        }
        public Guid AsGuid()
        {
            return (Guid)base.ObjValue;
        }
    }
}