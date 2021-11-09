using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.missions.domain
{
    [Owned]
    public class MissionId : EntityId
    {

        protected MissionId() : base()
        {
        }

        public MissionId(Guid value) : base(value)
        {
        }

        public MissionId(String value) : base(value)
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