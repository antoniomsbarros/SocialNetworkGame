using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.players.domain
{
    public class PlayerId : EntityId
    {
        public PlayerId(Guid guid) : base(guid)
        {
        }

        public PlayerId(String value) : base(value)
        {
        }
    }
}