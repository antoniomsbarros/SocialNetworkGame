using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;
using System;
using LEI_21s5_3dg_41.Domain.Tag;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class RelationShip : Entity<RelationShipId>
    {
        public PlayerId PlayerId { get; private set; } // Player related with

        public ConnectionStrenght ConnectionStrenght { get; private set; }

        public List<TagId> TagsList { get; private set; }

        public RelationShip(PlayerId player, ConnectionStrenght connectionStrenght, List<TagId> tagsList)
        {
            if (tagsList.Capacity > 0)
                this.TagsList = new(tagsList);
            else
                throw new BusinessRuleValidationException("At least 1 tag must be related to a relationship");

            this.Id = new RelationShipId(Guid.NewGuid());
            this.PlayerId = player;
            this.ConnectionStrenght = connectionStrenght;
        }

        public RelationShip(PlayerId player, ConnectionStrenght connectionStrenght, TagId tag)
        {
            this.Id = new RelationShipId(Guid.NewGuid());
            this.PlayerId = player;
            this.ConnectionStrenght = connectionStrenght;
            this.TagsList = new();
            this.TagsList.Add(tag);
        }

        public bool AddTag(TagId newTag)
        {
            if (this.TagsList.Contains(newTag))
                return false;

            this.TagsList.Add(newTag);
            return true;
        }

        public bool RemoveTag(TagId tagToRemove)
        {
            if (!this.TagsList.Contains(tagToRemove))
                return false;

            this.TagsList.Remove(tagToRemove);
            return true;
        }

        public int ComputeRelationStrenght()
        {
            throw new NotImplementedException("not implemented yet");
        }


    }
}