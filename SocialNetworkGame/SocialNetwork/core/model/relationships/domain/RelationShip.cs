using System.Collections.Generic;
using System;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.relationships.domain
{
    public class Relationship : Entity<RelationshipId>, IAggregateRoot
    {
        public PlayerId PlayerDest { get; private set; }

        public PlayerId PlayerOrig { get; private set; }

        public ConnectionStrength ConnectionStrength { get; private set; }

        public List<TagId> TagsList { get; private set; }

        protected Relationship()
        {
            // for ORM
        }

        protected Relationship(RelationshipId id, PlayerId playerDest, PlayerId playerOrig,
            ConnectionStrength connectionStrength, List<TagId> tagList)
        {
            Id = id;
            PlayerDest = playerDest;
            PlayerOrig = playerOrig;
            ConnectionStrength = connectionStrength;
            TagsList = new(tagList);
        }

        public Relationship(PlayerId playerDest, PlayerId playerOrig, ConnectionStrength connectionStrength,
            List<TagId> tagsList)
        {
            Id = new RelationshipId(Guid.NewGuid());
            PlayerDest = playerDest;
            PlayerOrig = playerOrig;
            ConnectionStrength = connectionStrength;
            TagsList = new(tagsList);
        }

        public Relationship(PlayerId playerDest, PlayerId playerOrig, ConnectionStrength connectionStrength,
            params TagId[] tags)
        {
            Id = new RelationshipId(Guid.NewGuid());
            PlayerDest = playerDest;
            PlayerOrig = playerOrig;
            ConnectionStrength = connectionStrength;
            TagsList = new(tags);
        }

        public bool AssignTag(TagId newTag)
        {
            if (TagsList.Contains(newTag))
                return false;

            TagsList.Add(newTag);
            return true;
        }

        public bool RemoveTag(TagId tagToRemove)
        {
            return TagsList.Remove(tagToRemove);
        }

        public void AssignConnectionStrength(ConnectionStrength connectionStrength)
        {
            ConnectionStrength = connectionStrength;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Relationship))
                return false;

            Relationship otherRelationShip = (Relationship) obj;

            return otherRelationShip.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public void ChangeConnectionStrength(int connectionStrength)
        {
            if (connectionStrength > 0)
                ConnectionStrength = new ConnectionStrength(connectionStrength);
        }

        public void ChangeTags(List<TagId> tags)
        {
            if (tags.Count > 0)
            {
                TagsList.Clear();
                TagsList.AddRange(tags);
            }
        }

        public void ChangePlayerDest(String playerDest)
        {
            if (!string.IsNullOrEmpty(playerDest))
                PlayerDest = new PlayerId(playerDest);
        }

        public void ChangePlayerOrig(String playerOrig)
        {
            if (!string.IsNullOrEmpty(playerOrig))
                PlayerOrig = new PlayerId(playerOrig);
        }

        public RelationshipDto ToDto()
        {
            return new RelationshipDto(Id.Value, PlayerDest.Value, PlayerOrig.Value,
                ConnectionStrength.Strength, TagsList.ConvertAll(tag => tag.Value));
        }
    }
}