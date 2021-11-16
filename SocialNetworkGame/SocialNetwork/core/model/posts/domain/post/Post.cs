using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.domain.comment;
using SocialNetwork.core.model.posts.domain.reaction;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.posts.domain.post
{
    public class Post : Entity<PostId>, IAggregateRoot
    {
        public TextBox PostText { get; private set; }

        public PlayerId PlayerCreator { get; private set; }

        public List<Tag> Tags { get; private set; }

        public List<Reaction> Reactions { get; private set; }

        public List<Comment> Comments { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Post()
        {
            // for ORM
        }

        protected Post(PostId id, TextBox postText, Player playerCreator, List<Tag> tagsList, List<Reaction> reactionsList,
            List<Comment> commentsList, CreationDate creationDate)
        {
            this.Id = id;
            this.PostText = postText;
            this.PlayerCreator = playerCreator.Id;
            this.Tags = new(tagsList);
            this.Reactions = new(reactionsList);
            this.Comments = new(commentsList);
            this.CreationDate = creationDate;
        }

        public Post(TextBox postText, Player playerCreator, List<Tag> tagsList)
        {
            this.Id = new PostId(Guid.NewGuid());
            this.PostText = postText;
            this.PlayerCreator = playerCreator.Id;
            this.Tags = new(tagsList);
            this.Reactions = new();
            this.Comments = new();
            this.CreationDate = new();
        }

        public Post(TextBox postText, Player playerCreator)
        {
            this.Id = new PostId(Guid.NewGuid());
            this.PostText = postText;
            this.PlayerCreator = playerCreator.Id;
            this.Tags = new();
            this.Reactions = new();
            this.Comments = new();
            this.CreationDate = new();
        }

        public bool AssignTag(Tag newTag)
        {
            if (this.Tags.Contains(newTag))
                return false;

            this.Tags.Add(newTag);
            return true;
        }

        public bool RemoveTag(Tag tagToRemove)
        {
            return this.Tags.Remove(tagToRemove);
        }

        public bool AddReaction(Reaction reaction)
        {
            if (this.Reactions.Contains(reaction))
                return false;

            this.Reactions.Add(reaction);
            return true;
        }

        public bool RemoveReaction(Reaction reaction)
        {
            return this.Reactions.Remove(reaction);
        }

        public bool AddComment(Comment comment)
        {
            if (this.Comments.Contains(comment))
                return false;

            this.Comments.Add(comment);
            return true;
        }

        public bool RemoveComment(Comment comment)
        {
            return this.Comments.Remove(comment);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Post))
                return false;

            Post otherPost = (Post)obj;

            return otherPost.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }

}