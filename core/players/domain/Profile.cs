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

        protected Profile()
        {
            // for ORM
        }

        public Profile(Name name, List<Tag> tagList)
        {
            this.Id = new ProfileId(Guid.NewGuid());
            this.Name = name;

            if (tagList.Count == 0)
                throw new BusinessRuleValidationException("The profile must have at least one Tag");

            this.TagsList = new(tagList);
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