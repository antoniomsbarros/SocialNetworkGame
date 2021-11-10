using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    // Later this could be changed if the Facebook API is going to be used

    public class FacebookProfile : IValueObject
    {
        public string FacebookProfileLink { get; }

        protected FacebookProfile()
        {
            // for ORM
        }

        public FacebookProfile(string link)
        {
            this.FacebookProfileLink = link; // for now there's no validation for this
        }
    }
}
