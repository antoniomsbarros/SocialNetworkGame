using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.players.domain
{
    public class PlayerId : EntityId
    {
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
