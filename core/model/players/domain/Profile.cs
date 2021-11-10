using System.Collections.Generic;
using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class Profile : Entity<ProfileId>
    {
        public Name Name { get; private set; }

        public EmotionalStatus EmotionalStatus { get; private set; }

        public List<Tag> TagsList { get; private set; }

        protected Profile()
        {
            // for ORM
        }

        protected Profile(ProfileId id, Name name, EmotionalStatus emotionalStatus, List<Tag> tagsList)
        {
            this.Id = id;
            this.Name = name;
            this.EmotionalStatus = emotionalStatus;
            this.TagsList = new(tagsList);
        }

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
            return TagsList.Remove(tagToRemove);
        }

        public void SetNameTo(Name newName)
        {
            this.Name = newName;
        }

        public void SetEmotionalStatusTo(EmotionalStatus emotionalStatus)
        {
            this.EmotionalStatus = emotionalStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Profile))
                return false;

            Profile otherProfile = (Profile) obj;

            return otherProfile.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}