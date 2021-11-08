using System.Collections.Generic;
using System;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class Profile : Entity<ProfileId>
    {
        public Name Name { get; private set; }

        // Emotional Status -> Study better how it will be implemented 

        public List<Tag> TagsList { get; private set; }

        public Profile(Name name)
        {
            this.Id = new ProfileId(Guid.NewGuid());
            this.Name = name;
            this.TagsList = new();
        }

        public bool AddTag(Tag newTag)
        {
            if (TagsList.Contains(newTag))
                return false;

            TagsList.Add(newTag);
            return true;
        }

        public bool RemoveTag(Tag tagToRemove)
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