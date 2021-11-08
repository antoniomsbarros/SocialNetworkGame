using System;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Players;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Post;
using LEI_21s5_3dg_41.Domain.Comment;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class Post : Entity<PostId>, IAggregateRoot
    {
        public string postText { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public Tag tag { get; private set; }

        public DateTime date {get; private set; }

        public List<ReactionId> listOfReactions = new List<ReactionId>();

        public List<CommentId> listOfComments = new List<CommentId>();


        public Post(string postText, PlayerId playerId, Tag tag, DateTime date, List<ReactionId> listOfReactions, List<CommentId> listOfComments) {
            if (playerId == null)
                throw new BusinessRuleValidationException("Every Post requires a Player");

            this.Id = new PostId(Guid.NewGuid());
            this.postText = postText;
            this.playerId = playerId;
            this.tag = tag;
            this.date = date;
            this.listOfReactions = listOfReactions;
            this.listOfComments = listOfComments;
        }


    }
}