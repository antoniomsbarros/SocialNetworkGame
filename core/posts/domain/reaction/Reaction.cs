using System;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.reaction
{
    public class Reaction : Entity<ReactionId>
    {
        public ReactionValue ReactionValue { get; private set; }

        public Player Player { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Reaction()
        {
            // for ORM
        }

        protected Reaction(ReactionId id, ReactionValue reactionValue, Player player, CreationDate creationDate)
        {
            this.Id = id;
            this.ReactionValue = reactionValue;
            this.Player = player;
            this.CreationDate = creationDate;
        }

        public Reaction(ReactionValue reaction, Player player)
        {
            this.ReactionValue = reaction;
            this.Player = player;
            this.CreationDate = new();
        }

        public void ChangeReactionTo(ReactionValue newReaction)
        {
            this.ReactionValue = newReaction;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Reaction))
                return false;

            Reaction otherReaction = (Reaction)obj;

            return otherReaction.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

    }
}