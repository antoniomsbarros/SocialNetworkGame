using System;
using LEI_21s5_3dg_41.Domain.Players;

using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Comment;
using LEI_21s5_3dg_41.Domain.Shared;
namespace LEI_21s5_3dg_41.Domain.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string postText { get;  private set; }

        public string playerId { get;  private set; }

        public string tagId { get; private set; }

        public DateTime date {get; private set; }

        public List<string> listOfReactions {get; private set; }

        public List<string> listOfComments {get; private set; }
        
        public PostDto(Guid Id, string postText, string playerId, string tagId, DateTime date, List<string> listOfReactions,List<string> listOfComments)
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