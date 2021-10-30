using System;
using LEI_21s5_3dg_41.Domain.Player;
using LEI_21s5_3dg_41.Domain.Tag;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Comment;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string postText { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public TagId tagId { get; private set; }

        public DateTime date {get; private set; }

        public List<ReactionId> listOfReactions = new List<ReactionId>();

        public List<CommentId> listOfComments = new List<CommentId>();
        
        public PostDto(Guid Id, string postText, PlayerId playerId, TagId tagId, DateTime date, List<ReactionId> listOfReactions,List<CommentId> listOfComments)
        {
            this.Id = Id;
            this.postText = postText;
            this.playerId = playerId;
            this.tagId = tagId;
            this.date = date;
            this.listOfReactions = listOfReactions;
            this.listOfComments = listOfComments;
        }
    }
}