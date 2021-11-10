using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;
namespace SocialNetwork.core.connectionRequests.domain
{
    [Owned]
    public class ConnectionRequestId : EntityId
    {
        protected ConnectionRequestId() : base()
        {
        }

        public ConnectionRequestId(Guid guid) : base(guid)
        {
        }
        public ConnectionRequestId(String value) : base(value)
        {
        }
        protected override Object createFromString(String text)
        {
            return text;
        }

        public override String AsString()
        {
            return base.Value;
        }
    }
}