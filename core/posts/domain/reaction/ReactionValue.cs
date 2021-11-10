using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

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

        public static ReactionValue ValueOf(ReactionValueEnum reaction)
        {
            return new(reaction);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(ReactionValue))
                return false;

            ReactionValue otherReactionValue = (ReactionValue)obj;

            return otherReactionValue.Reaction.Equals(this.Reaction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Reaction, DateTime.Now);
        }
    }

}
