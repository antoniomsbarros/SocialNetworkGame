using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.reaction
{
    public enum ReactionValueEnum
    {
        Like,
        Dislike
    }

    [Owned]
    public class ReactionValue : IValueObject
    {
        public ReactionValueEnum Reaction { get; }

        protected ReactionValue()
        {
            // for ORM
        }

        public ReactionValue(ReactionValueEnum reaction)
        {
            this.Reaction = reaction;
        }
    }

}
