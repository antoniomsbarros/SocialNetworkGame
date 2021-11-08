using System;
using LEI_21s5_3dg_41.Domain.Players;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Reaction
{
    public class ReactionDto
    {
        public Guid Id { get; set; }
        public string reaction { get;  private set; }

        public string playerId { get;  private set; }

        public ReactionDto(Guid Id, string reaction, string playerId)
        {
            this.Id = Id;
            this.reaction = reaction;
            this.playerId = playerId;
        }
    }
}