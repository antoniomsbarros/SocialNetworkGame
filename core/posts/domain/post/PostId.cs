using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.posts.domain.post
{
    [Owned]
    public class PostId : EntityId
    {
        protected PostId() : base()
        {
        }
        public PostId(Guid value) : base(value)
        {
        }

        public PostId(String value) : base(value)
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