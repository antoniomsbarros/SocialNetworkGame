using System.Collections.Generic;
using System;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.DTO;
using lapr5_3dg.DTO;
using SocialNetwork.core.model.players.dto;

namespace SocialNetwork.core.model.relationships.domain
{
    public class Relationship : Entity<RelationshipId>, IAggregateRoot
    {
        public PlayerId PlayerDest { get; private set; }

        public PlayerId PlayerOrig { get; private set; }

        public ConnectionStrenght ConnectionStrenght { get; private set; }

        public List<Tag> TagsList { get; private set; }

        protected Relationship()
        {
            // for ORM
        }

        protected Relationship(RelationshipId id, PlayerId playerDest, PlayerId playerOrig, ConnectionStrenght connectionStrenght, List<Tag> tagList)
        {
            this.Id = id;
            this.PlayerDest = playerDest;
            this.PlayerOrig = playerOrig;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tagList);
        }

        public Relationship(PlayerId playerDest, PlayerId playerOrig, ConnectionStrenght connectionStrenght, List<Tag> tagsList)
        {
            this.Id = new RelationshipId(Guid.NewGuid());
            this.PlayerDest = playerDest;
            this.PlayerOrig= playerOrig;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tagsList);
        }

        public Relationship(PlayerId playerDest, PlayerId playerOrig, ConnectionStrenght connectionStrenght, params Tag[] tags)
        {
            this.Id = new RelationshipId(Guid.NewGuid());
            this.PlayerDest = playerDest;
            this.PlayerOrig = playerOrig;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new(tags);
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

            if (obj.GetType() != typeof(Relationship))
                return false;

            Relationship otherRelationShip = (Relationship)obj;

            return otherRelationShip.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }

        public void ChangeConnectionStrenght(int connectionStrenght) 
        {
            if(connectionStrenght > 0)
                ConnectionStrenght = new ConnectionStrenght(connectionStrenght);
        }

        public void ChangeTags(List<string> tags ) 
        {
            if(tags != null || tags.Count > 0)
            {
                TagsList = new List<Tag>();
                tags.ForEach(tag => TagsList.Add(new Tag(tag)));
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

        public RelationshipDto toDTO()
        {
            List<string> tagToDto = new List<string>();
            TagsList.ForEach(tag => tagToDto.Add(tag.Name));
            return new RelationshipDto(this.Id.Value, PlayerDest.Value, PlayerOrig.Value, 
                ConnectionStrenght.Strenght, tagToDto);
        }

    }
}
