using System;
using System.Collections.Generic;
using SocialNetwork.core.shared;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.reaction;

namespace SocialNetwork.core.posts.domain.comment
{
    public class Comment : Entity<CommentId>
    {
        public List<Reaction> Reactions { get; private set; }

        public Player PlayerCreator { get; private set; }

        public TextBox CommentText { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Comment()
        {
            // for ORM
        }

        protected Comment(CommentId id, Player playerCreator, TextBox commentText, CreationDate creationDate, List<Reaction> reactions)
        {
            this.Id = id;
            this.PlayerCreator = playerCreator;
            this.CommentText = commentText;
            this.CreationDate = creationDate;
            this.Reactions = new(reactions);
        }

        public Comment(Player playerCreator, TextBox commentText)
        {
            this.Id = new CommentId(Guid.NewGuid());
            this.PlayerCreator = playerCreator;
            this.CommentText = commentText;
            this.CreationDate = new();
            this.Reactions = new();
        }

        public void ReactCommentWith(Reaction reaction) // For now it will not be considered this situations :
        {                                               // Change and Remove a Reaction (not specified by the client)
            this.Reactions.Add(reaction);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Comment))
                return false;

            Comment otherComment = (Comment)obj;

            return otherComment.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}