using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.players.domain
{
    [Owned]
    public class PlayerId : EntityId
    {
        protected PlayerId() : base()
        {
        }

        public PlayerId(Guid guid) : base(guid)
        {
        }
        public PlayerId(String value) : base(value)
        {
        }
        protected override Object createFromString(String text)
        {
            return text;
        }

        public override String AsString()
        {
            return (String)base.Value;
        }

    }
}
