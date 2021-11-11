using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.domain
{

    public class RelationshipBuilder : IDomainBuilder<Relationship>
    {
        private Relationship relationship;

        private Player playerDest;

        private ConnectionStrenght connectionStrenght;

        private readonly List<Tag> tagsList = new();

        public RelationshipBuilder WithPlayer(Player player)
        {
            this.playerDest = player;
            return this;
        }

        public RelationshipBuilder WithTag(Tag tag)
        {
            this.tagsList.Add(tag);
            return this;
        }

        public RelationshipBuilder WithConnectionStrenght(ConnectionStrenght connectionStrenght)
        {
            this.connectionStrenght = connectionStrenght;
            return this;
        }

        public Relationship BuildOrIgnore()
        {
            if (this.relationship != null)
                return this.relationship;
            else if (this.connectionStrenght != null && this.tagsList.Count > 0)
                this.relationship = new(this.playerDest.Id, this.connectionStrenght, this.tagsList);
            else if (this.connectionStrenght != null)
            //TODO checkar se lista de tags pode ir vazia
                this.relationship = new(this.playerDest.Id, this.connectionStrenght, new List<Tag>());
            else
            {
                throw new System.InvalidOperationException();
            }

            return this.relationship;
        }

        public Relationship Build()
        {
            Relationship rel = BuildOrIgnore();
            this.relationship = null;
            return rel;
        }
    }
}

