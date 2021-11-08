using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.reaction
{
    public enum ReactionValueEnum
    {
        Like,
        Dislike
    }
    public class ReactionValue : IValueObject
    {
        public ReactionValueEnum Reaction { get; }

        public ReactionValue(ReactionValueEnum reaction)
        {
            this.Reaction = reaction;
        }
    }

}
