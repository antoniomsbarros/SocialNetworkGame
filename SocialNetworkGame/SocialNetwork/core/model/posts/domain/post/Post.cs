using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.domain.comment;
using SocialNetwork.core.model.posts.domain.reaction;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.posts.domain.post
{
    public class Post : Entity<PostId>, IAggregateRoot
    {
        public TextBox PostText { get; private set; }

        public PlayerId PlayerCreator { get; private set; }

        public List<TagId> Tags { get; private set; }

        public List<Reaction> Reactions { get; private set; }

        public List<Comment> Comments { get; private set; }

        public CreationDate CreationDate { get; private set; }

        protected Post()
        {
            // for ORM
        }

        protected Post(PostId id, TextBox postText, PlayerId playerCreator, List<TagId> tagsList,
            List<Reaction> reactionsList, List<Comment> commentsList, CreationDate creationDate)
        {
            Id = id;
            PostText = postText;
            PlayerCreator = playerCreator;
            Tags = new(tagsList);
            Reactions = new(reactionsList);
            Comments = new(commentsList);
            CreationDate = creationDate;
        }

        public Post(TextBox postText, PlayerId playerCreator, List<TagId> tagsList)
        {
            Id = new PostId(Guid.NewGuid());
            PostText = postText;
            PlayerCreator = playerCreator;
            Tags = new(tagsList);
            Reactions = new();
            Comments = new();
            CreationDate = new();
        }

        public Post(TextBox postText, PlayerId playerCreator)
        {
            Id = new PostId(Guid.NewGuid());
            PostText = postText;
            PlayerCreator = playerCreator;
            Tags = new();
            Reactions = new();
            Comments = new();
            CreationDate = new();
        }

        public bool AssignTag(TagId newTag)
        {
            if (Tags.Contains(newTag))
                return false;

            Tags.Add(newTag);
            return true;
        }

        public bool RemoveTag(TagId tagToRemove)
        {
            return Tags.Remove(tagToRemove);
        }

        public bool AddReaction(Reaction reaction)
        {
            if (Reactions.Contains(reaction))
                return false;

            Reactions.Add(reaction);
            return true;
        }

        public bool RemoveReaction(Reaction reaction)
        {
            return Reactions.Remove(reaction);
        }

        public bool AddComment(Comment comment)
        {
            if (Comments.Contains(comment))
                return false;

            Comments.Add(comment);
            return true;
        }

        public bool RemoveComment(Comment comment)
        {
            return Comments.Remove(comment);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Post))
                return false;

            Post otherPost = (Post) obj;

            return otherPost.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}