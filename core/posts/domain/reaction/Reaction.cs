using System;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.reaction
{
    public class Reaction : Entity<ReactionId>
    {
        public ReactionValueEnum ReactionValue { get; private set; }
        public Player Player { get; private set; }
        public Reaction(ReactionValueEnum reaction, Player player)
        {
            this.Player = player ?? throw new BusinessRuleValidationException("Every Reaction requires a Player");

            this.Id = new ReactionId(Guid.NewGuid());
            this.ReactionValue = reaction;
        }

        public void ChangeReactionTo(ReactionValueEnum newReaction)
        {
            this.ReactionValue = newReaction;
        }

    }
}