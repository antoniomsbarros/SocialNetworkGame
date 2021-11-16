using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.domain
{

    public class RelationshipBuilder : IDomainBuilder<Relationship>
    {
        private Relationship relationship;

        private PlayerId playerDest;

        private PlayerId playerOrig;

        private ConnectionStrenght connectionStrenght;

        private readonly List<Tag> tagsList = new();

        public RelationshipBuilder WithPlayerDest(PlayerId playerDest)
        {
            this.playerDest = playerDest;
            return this;
        }

        public RelationshipBuilder WithPlayerOrig(PlayerId playerOrig)
        {
            this.playerOrig = playerOrig;
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
                this.relationship = new(this.playerDest, this.playerOrig,this.connectionStrenght, this.tagsList);
            else if (this.connectionStrenght != null)
            //TODO checkar se lista de tags pode ir vazia
                this.relationship = new(this.playerDest, this.playerOrig,this.connectionStrenght, new List<Tag>());
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

