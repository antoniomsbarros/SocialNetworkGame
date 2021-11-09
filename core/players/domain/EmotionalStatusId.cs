using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    [Owned]
    public class EmotionalStatusId : EntityId
    {

        protected EmotionalStatusId() : base()
        {
        }

        public EmotionalStatusId(Guid value) : base(value)
        {
        }

        public EmotionalStatusId(String value) : base(value)
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