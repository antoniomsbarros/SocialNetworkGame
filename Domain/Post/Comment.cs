using System;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Player;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Comment
{
    public class Comment : Entity<CommentId>
    {
        public ReactionEnum reaction { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public string commentText {get; private set; }

        public DateTime date {get; private set; }
        

        public Comment(ReactionEnum reaction, PlayerId playerId, string commentText, DateTime date) {
            if (playerId == null)
                throw new BusinessRuleValidationException("Every Comment requires a Player");

            this.Id = new CommentId(Guid.NewGuid());
            this.reaction = reaction;
            this.playerId = playerId;
            this.commentText = commentText;
            this.date = date;
        }


    }
}