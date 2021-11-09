using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.posts.domain.reaction
{
    [Owned]
    public class ReactionId : EntityId
    {

        protected ReactionId() : base()
        {
        }

        public ReactionId(Guid value) : base(value)
        {
        }
        public ReactionId(String value) : base(value)
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