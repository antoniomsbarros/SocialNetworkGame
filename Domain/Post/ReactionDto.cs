using System;
using LEI_21s5_3dg_41.Domain.Player;
using LEI_21s5_3dg_41.Domain.Tag;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Reaction
{
    public class ReactionDto
    {
        public Guid Id { get; set; }
        public ReactionEnum reaction { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public ReactionDto(Guid Id, ReactionEnum reaction, PlayerId playerId)
        {
            this.Id = Id;
            this.reaction = reaction;
            this.playerId = playerId;
        }
    }
}