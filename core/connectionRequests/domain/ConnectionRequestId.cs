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
        public ConnectionRequestId(String value) : base(value)
        {
        }

        override
        protected Object createFromString(String text)
        {
            return text;
        }
        override
        public String AsString()
        {
            return (String)base.Value;
        }
    }
}
