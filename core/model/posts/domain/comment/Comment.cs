using System;
using System.Collections.Generic;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.domain.reaction;

namespace SocialNetwork.core.model.posts.domain.comment
{
    public class Comment : Entity<CommentId>
    {
        public List<Reaction> Reactions { get; private set; }

        public PlayerId PlayerCreator { get; private set; }

        public TextBox CommentText { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Comment()
        {
            // for ORM
        }

        protected Comment(CommentId id, Player playerCreator, TextBox commentText, CreationDate creationDate, List<Reaction> reactions)
        {
            this.Id = id;
            this.PlayerCreator = playerCreator.Id;
            this.CommentText = commentText;
            this.CreationDate = creationDate;
            this.Reactions = new(reactions);
        }

        public Comment(Player playerCreator, TextBox commentText)
        {
            this.Id = new CommentId(Guid.NewGuid());
            this.PlayerCreator = playerCreator.Id;
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