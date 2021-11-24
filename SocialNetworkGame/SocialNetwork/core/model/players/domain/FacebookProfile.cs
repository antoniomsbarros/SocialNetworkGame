using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    // Later this could be changed if the Facebook API is going to be used

    public class FacebookProfile : IValueObject
    {
        public string FacebookProfileLink { get; }

        private const string Default = "Not specified";

        public FacebookProfile()
        {
            FacebookProfileLink = Default;
        }

        public FacebookProfile(string link)
        {
            if (link == null || link.Trim().Length == 0)
                FacebookProfileLink = Default;
            else
                FacebookProfileLink = link; // for now there's no validation for this
        }

        public static FacebookProfile ValueOf(string link)
        {
            return new(link);
        }
    }
}