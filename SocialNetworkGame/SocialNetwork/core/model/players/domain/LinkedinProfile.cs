using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    // Read the comments from FacebookProfile

    public class LinkedinProfile : IValueObject
    {
        public string LinkedinProfileLink { get; }

        private const string Default = "Not specified";

        public LinkedinProfile()
        {
            LinkedinProfileLink = Default;
        }

        public LinkedinProfile(string link)
        {
            if (link == null || link.Trim().Length == 0)
                LinkedinProfileLink = Default;
            else
                LinkedinProfileLink = link;
        }

        public static LinkedinProfile ValueOf(string link)
        {
            return new(link);
        }
    }
}