using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class Player : Entity<PlayerId>, IAggregateRoot, IDTOable<PlayerDto>
    {
        public Email Email { get; private set; } // SystemUserId

        public PhoneNumber PhoneNumber { get; private set; }

        public FacebookProfile FacebookProfile { get; private set; }

        public LinkedinProfile LinkedinProfile { get; private set; }

        public DateOfBirth DateOfBirth { get; private set; }

        public Name Name { get; private set; }

        public EmotionalStatus EmotionalStatus { get; private set; }

        public List<Tag> TagsList { get; private set; }

        protected Player()
        {
            // for ORM
        }

        protected Player(PlayerId id, Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth, Name name, EmotionalStatus emotionalStatus,
            List<Tag> tagsList)
        {
            this.Id = id;
            this.Email = email; // SystemUserId
            this.PhoneNumber = phoneNumber;
            LinkFacebook(facebookProfile);
            LinkLinkedin(linkedinProfile);
            this.DateOfBirth = dateOfBirth;
            this.Name = name;
            this.EmotionalStatus = emotionalStatus;
            this.TagsList = new(tagsList);
        }

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth, Name name, EmotionalStatus emotionalStatus)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Name = name;
            this.EmotionalStatus = emotionalStatus;
            this.TagsList = new();
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.FacebookProfile = new();
            this.LinkedinProfile = new();
            this.EmotionalStatus = new(EmotionalStatusEnum.NotSpecified);
            this.TagsList = new();
        }

        public void LinkFacebook(FacebookProfile facebookProfile)
        {
            this.FacebookProfile = facebookProfile ?? new();
        }

        public void LinkLinkedin(LinkedinProfile linkedinProfile)
        {
            this.LinkedinProfile = linkedinProfile ?? new();
        }

        public bool AssignTag(Tag newTag)
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

        public void ChangeName(Name newName)
        {
            this.Name = newName;
        }

        public void ChangeDateOfBirth(DateOfBirth dateOfBirth)
        {
            this.DateOfBirth = dateOfBirth;
        }
        public void ChangeFacebookProfile(FacebookProfile facebookProfile)
        {
            this.FacebookProfile = facebookProfile;
        }
        public void ChangeLinkedinProfile(LinkedinProfile linkedinProfile)
        {
            this.LinkedinProfile = linkedinProfile;
        }
        public void ChangePhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
 
        public void ChangeTags(List<Tag> newTagsList)
        {
            TagsList.Clear();
            TagsList.AddRange(newTagsList);
        }

        public void SetEmotionalStatusTo(EmotionalStatus emotionalStatus)
        {
            this.EmotionalStatus = emotionalStatus;
        }

        //TODO FACEBOOK AND LINKEDIN API IMPLEMENTATION MISSING
        public PlayerDto ToDto()
        {
            if (FacebookProfile == null)
                FacebookProfile = new FacebookProfile("until no facebook api");
            if (LinkedinProfile == null)
                LinkedinProfile = new LinkedinProfile("until no linkedin api");
            return new PlayerDto(this.Id.Value, this.Email.EmailAddress, this.PhoneNumber.Number,
                this.FacebookProfile.FacebookProfileLink, this.LinkedinProfile.LinkedinProfileLink,
                this.DateOfBirth.Date, this.Name.ShortName, this.Name.FullName,
                this.EmotionalStatus.CurrentEmotionalStatus,
                this.TagsList.ConvertAll(tag => tag.Name));
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Player))
                return false;

            Player otherPlayer = (Player) obj;

            return otherPlayer.Email.Equals(this.Email);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}