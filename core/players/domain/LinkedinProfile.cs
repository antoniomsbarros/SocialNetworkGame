using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    // Read the comments from FacebookProfile

    [Owned]
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
