using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.systemUsers.domain
{
    public class Username : EntityId
    {
        protected Username()
        {
            // for ORM
        }

        public Username(string username) : base(username)
        {
        }

        protected override Username createFromString(string text)
        {
            return new(text);
        }

        public override string AsString()
        {
            return base.Value;
        }
    }
}