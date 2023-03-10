using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.missions.domain
{
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
    }
}