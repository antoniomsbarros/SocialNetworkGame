using System;
using System.Collections.Generic;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.comment;
using SocialNetwork.core.posts.domain.reaction;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.domain.post
{
    public class Post : Entity<PostId>, IAggregateRoot
    {
        public TextBox PostText { get; private set; }

        public Player PlayerCreator { get; private set; }

        public Tag Tag { get; private set; }

        public CreationDate CreationDate { get; private set; }

        public List<Reaction> ListOfReactions { get; private set; }

        public List<Comment> ListOfComments { get; private set; }

        protected Post()
        {
            // for ORM
        }
        public Post(TextBox postText, Player player, Tag tag, CreationDate date, List<Reaction> listOfReactions, List<Comment> listOfComments)
        {
            this.PlayerCreator = player ?? throw new BusinessRuleValidationException("Every Post requires a Player");

            this.Id = new PostId(Guid.NewGuid());
            this.PostText = postText;
            this.Tag = tag;
            this.CreationDate = date;
            this.ListOfReactions = listOfReactions;
            this.ListOfComments = listOfComments;
        }
    }

}