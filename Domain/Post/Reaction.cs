using System;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Player;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Reaction
{
    public class Reaction : Entity<ReactionId>
    {
        public ReactionEnum reaction { get;  private set; }

        public PlayerId playerId { get;  private set; }


        public Reaction(ReactionEnum reaction, PlayerId playerId) {
            if (playerId == null)
                throw new BusinessRuleValidationException("Every Reaction requires a Player");

            this.Id = new ReactionId(Guid.NewGuid());
            this.reaction = reaction;
            this.playerId = playerId;
        }


    }
}