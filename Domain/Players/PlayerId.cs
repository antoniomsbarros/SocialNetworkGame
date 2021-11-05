using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Players
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
