using System.Collections.Generic;
using System;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.relationships.domain
{
    public class RelationShip : Entity<RelationshipId>, IAggregateRoot
    {
        public PlayerId PlayerDest { get; private set; } // Player who has a relationship with

        public ConnectionStrenght ConnectionStrenght { get; private set; }

        public List<Tag> TagsList { get; private set; }

        protected RelationShip()
        {
            // for ORM
        }

        protected RelationShip(RelationshipId id, Player playerDest, ConnectionStrenght connectionStrenght, List<Tag> tagList)
        {
            this.Id = id;
            this.PlayerDest = playerDest.Id;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tagList);
        }

        public RelationShip(Player playerDest, ConnectionStrenght connectionStrenght, List<Tag> tagsList)
        {
            this.Id = new RelationshipId(Guid.NewGuid());
            this.PlayerDest = playerDest.Id;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tagsList);
        }

        public RelationShip(Player player, ConnectionStrenght connectionStrenght, params Tag[] tags)
        {
            this.Id = new RelationshipId(Guid.NewGuid());
            this.PlayerDest = player.Id;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tags);
        }

        public RelationShip(Player player)
        {
            this.Id = new RelationshipId(Guid.NewGuid());
            this.PlayerDest = player.Id;
            this.ConnectionStrenght = ConnectionStrenght.ValueOf(0); // Connection strenght by omission
            this.TagsList = new();
        }

        public bool AssignTag(Tag newTag)
        {
            if (this.TagsList.Contains(newTag))
                return false;

            this.TagsList.Add(newTag);
            return true;
        }

        public bool RemoveTag(Tag tagToRemove)
        {
            return this.TagsList.Remove(tagToRemove);
        }

        public void AssignConnectionStrenght(ConnectionStrenght connectionStrenght)
        {
            this.ConnectionStrenght = connectionStrenght;
        }

        public int ComputeRelationStrenght()
        {
            throw new NotImplementedException("not implemented yet");
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(RelationShip))
                return false;

            RelationShip otherRelationShip = (RelationShip)obj;

            return otherRelationShip.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

    }
}
