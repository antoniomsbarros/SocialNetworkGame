using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    [Owned]
    public class ConnectionRequestId : EntityId
    {

        protected ConnectionRequestId() : base()
        {
        }

        public ConnectionRequestId(Guid value) : base(value)
        {
        }
        public ConnectionRequestId(String value) : base(value)
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