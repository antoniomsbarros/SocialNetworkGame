using System;
using System.Collections.Generic;
using SocialNetwork.core.shared;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.reaction;

namespace SocialNetwork.core.posts.domain.comment
{
    public class Comment : Entity<CommentId>
    {
        public List<Reaction> ListOfReactions { get; private set; }

        public Player PlayerCreator { get; private set; }

        public TextBox CommentText { get; private set; }

        public CreationDate CreationDate { get; private set; }

        public Comment(List<Reaction> listOfReactions, Player playerCreator, TextBox commentText, CreationDate creationDate)
        {
            this.PlayerCreator = playerCreator ?? throw new BusinessRuleValidationException("Every Comment requires a Player");
            this.Id = new CommentId(Guid.NewGuid());
            this.ListOfReactions = listOfReactions;
            this.CommentText = commentText;
            this.CreationDate = creationDate;
        }
    }
}