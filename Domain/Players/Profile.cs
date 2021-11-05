using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;
using LEI_21s5_3dg_41.Domain.Tag;

using System;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class Profile : Entity<ProfileId>
    {
        public Name Name { get; private set; }

        // Emotional Status -> Study better how it will be implemented 

        public List<TagId> TagsList { get; private set; }

        public Profile(Name name)
        {
            this.Id = new ProfileId(Guid.NewGuid());
            this.Name = name;
            this.TagsList = new();
        }

        public bool AddTag(TagId newTag)
        {
            if (TagsList.Contains(newTag))
                return false;

            TagsList.Add(newTag);
            return true;
        }

        public bool RemoveTag(TagId tagToRemove)
        {
            if (!TagsList.Contains(tagToRemove))
                return false;

            TagsList.Remove(tagToRemove);
            return true;
        }

        public void ChangeNameTo(Name newName)
        {
            this.Name = newName;
        }

    }
}