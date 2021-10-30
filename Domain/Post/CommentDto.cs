using System;
using LEI_21s5_3dg_41.Domain.Player;
using LEI_21s5_3dg_41.Domain.Tag;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }       
        public ReactionEnum reaction { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public string commentText {get; private set; }

        public DateTime date {get; private set; }

        public CommentDto(Guid Id, ReactionEnum reaction, PlayerId playerId,string commentText,DateTime date)
        {
            this.Id = Id;
            this.reaction = reaction;
            this.playerId = playerId;
            this.commentText = commentText;
        }
    }
}