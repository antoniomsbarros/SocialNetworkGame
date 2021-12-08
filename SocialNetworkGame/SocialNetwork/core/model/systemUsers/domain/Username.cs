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

        public static Username ValueOf(string id)
        {
            return new Username(id);
        }
    }
}