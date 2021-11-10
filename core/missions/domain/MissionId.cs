using SocialNetwork.core.shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace SocialNetwork.core.missions.domain
{
    [Owned]
    public class MissionId : EntityId
    {

        protected MissionId() : base()
        {
        }

        public MissionId(Guid guid) : base(guid)
        {
        }
        public MissionId(String value) : base(value)
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