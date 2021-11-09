using System;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.connectionRequests.domain
{
    [Owned]
    public class IntroductionRequestId : EntityId
    {
        public IntroductionRequestId(Guid value) : base(value)
        {
        }

        public IntroductionRequestId(String value) : base(value)
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