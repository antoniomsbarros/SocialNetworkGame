using System;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class ProfileId : EntityId
    {

        protected ProfileId() : base()
        {
            // for ORM
        }

        public ProfileId(Guid value) : base(value)
        {
        }

        public ProfileId(String value) : base(value)
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