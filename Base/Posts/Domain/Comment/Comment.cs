using System;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;

namespace LEI_21s5_3dg_41.Domain.Comment
{
    public class Comment : Entity<CommentId>
    {
        public List<ReactionId> listOfReactions {get; private set; }

        public PlayerId playerId { get;  private set; }

        public TextBox commentText {get; private set; }

        public CreationDate date {get; private set; }
        

        public Comment(List<ReactionId> listOfReactions, PlayerId playerId, TextBox commentText, CreationDate date) {
            if (playerId == null)
                throw new BusinessRuleValidationException("Every Comment requires a Player");

            this.Id = new CommentId(Guid.NewGuid());
            this.listOfReactions = listOfReactions;
            this.playerId = playerId;
            this.commentText = commentText;
            this.date = date;
        }


    }
}