using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.relationships.domain
{
    [Owned]
    public class RelationShipId : EntityId
    {

        protected RelationShipId() : base()
        {
        }

        public RelationShipId(Guid value) : base(value)
        {
        }

        public RelationShipId(String value) : base(value)
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