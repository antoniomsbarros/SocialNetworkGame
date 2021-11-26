using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.connectionRequests.domain
{
    public class ConnectionRequestId : EntityId
    {
        protected ConnectionRequestId()
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
            return Value;
        }
    }
}