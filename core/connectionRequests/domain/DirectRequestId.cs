using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    [Owned]
    public class DirectRequestId : EntityId
    {
        public DirectRequestId(Guid value) : base(value)
        {
        }

        public DirectRequestId(String value) : base(value)
        {
        }

        protected override Object createFromString(String text)
        {
            return new Guid(text);
        }
        public override String AsString()
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