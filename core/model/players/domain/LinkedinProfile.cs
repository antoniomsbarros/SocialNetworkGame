using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    // Read the comments from FacebookProfile

    public class LinkedinProfile : IValueObject
    {
        public string LinkedinProfileLink { get; }

        protected LinkedinProfile()
        {
            // for ORM
        }

        public LinkedinProfile(string link)
        {
            this.LinkedinProfileLink = link;
        }
    }
}
