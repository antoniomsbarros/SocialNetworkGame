using LEI_21s5_3dg_41.Domain.Player;
using LEI_21s5_3dg_41.Domain.Tag;
using System.Collections.Generic;
using System;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Reaction
{
    public class CreatingReactionDto
    {

        public ReactionEnum reaction { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public CreatingReactionDto(ReactionEnum reaction, PlayerId playerId)
        {
            this.reaction = reaction;
            this.playerId = playerId;
 
        }
    }
}