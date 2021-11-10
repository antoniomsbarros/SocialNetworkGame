using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.domain
{
    public class RelationShipBuilder : IDomainBuilder<RelationShip>
    {
        private RelationShip relationShip;

        private Player playerDest;

        private ConnectionStrenght connectionStrenght;

        private readonly List<Tag> tagsList = new();

        public RelationShipBuilder WithPlayer(Player player)
        {
            this.playerDest = player;
            return this;
        }

        public RelationShipBuilder WithTag(Tag tag)
        {
            this.tagsList.Add(tag);
            return this;
        }

        public RelationShipBuilder WithConnectionStrenght(ConnectionStrenght connectionStrenght)
        {
            this.connectionStrenght = connectionStrenght;
            return this;
        }

        public RelationShip BuildOrIgnore()
        {
            if (this.relationShip != null)
                return this.relationShip;
            else if (this.connectionStrenght != null && this.tagsList.Count > 0)
                this.relationShip = new(this.playerDest, this.connectionStrenght, this.tagsList);
            else if (this.connectionStrenght != null)
                this.relationShip = new(this.playerDest, this.connectionStrenght);
            else if (this.tagsList.Count > 0)
            {
                this.relationShip = new(this.playerDest);
                foreach (Tag nTag in tagsList)
                    this.relationShip.AssignTag(nTag);
            }
            else
            {
                throw new System.InvalidOperationException();
            }

            return this.relationShip;
        }

        public RelationShip Build()
        {
            RelationShip rel = BuildOrIgnore();
            this.relationShip = null;
            return rel;
        }
    }
}

