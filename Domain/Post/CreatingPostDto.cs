using LEI_21s5_3dg_41.Domain.Players;

using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Reaction;
using LEI_21s5_3dg_41.Domain.Comment;
using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class CreatingPostDto
    {
        public string postText { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public Tag tagId { get; private set; }

        public DateTime date {get; private set; }

        public List<ReactionId> listOfReactions = new List<ReactionId>();

        public List<CommentId> listOfComments = new List<CommentId>();

        public CreatingPostDto(string postText, PlayerId playerId, Tag tagId, DateTime date, List<ReactionId> listOfReactions,List<CommentId> listOfComments)
        {
            this.postText = postText;
            this.playerId = playerId;
            this.tagId = tagId;
            this.date = date;
            this.listOfReactions = listOfReactions;
            this.listOfComments = listOfComments;
        }
    }
}