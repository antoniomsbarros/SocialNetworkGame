using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.comment
{
    [Owned]
    public class CommentId : EntityId
    {
        protected CommentId() : base()
        {
        }

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