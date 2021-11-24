using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    //TODO FACEBOOK AND LINKEDIN API IMPLEMENTATION MISSING
    public class Player : Entity<PlayerId>, IAggregateRoot, IDTOable<PlayerDto>
    {
        public Email Email { get; private set; } // Email represents also his "System User Id"

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
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            LinkFacebook(facebookProfile);
            LinkLinkedin(linkedinProfile);
            DateOfBirth = dateOfBirth;
            Name = name;
            EmotionalStatus = emotionalStatus;
            TagsList = new(tagsList);
        }

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth, Name name, EmotionalStatus emotionalStatus)
        {
            Id = new PlayerId(Guid.NewGuid());
            Email = email;
            PhoneNumber = phoneNumber;
            FacebookProfile = facebookProfile;
            LinkedinProfile = linkedinProfile;
            DateOfBirth = dateOfBirth;
            Name = name;
            EmotionalStatus = emotionalStatus;
            TagsList = new();
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth)
        {
            Id = new PlayerId(Guid.NewGuid());
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            FacebookProfile = new();
            LinkedinProfile = new();
            EmotionalStatus = new(EmotionalStatusEnum.NotSpecified);
            TagsList = new();
        }

        public void LinkFacebook(FacebookProfile facebookProfile)
        {
            FacebookProfile = facebookProfile ?? new();
        }

        public void LinkLinkedin(LinkedinProfile linkedinProfile)
        {
            LinkedinProfile = linkedinProfile ?? new();
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
            EmotionalStatus = emotionalStatus;
        }

        public PlayerDto ToDto()
        {
            return new PlayerDto(Id.Value, Email.Address, PhoneNumber.Number,
                FacebookProfile.FacebookProfileLink, LinkedinProfile.LinkedinProfileLink,
                DateOfBirth.Date, Name.ShortName, Name.FullName,
                EmotionalStatus.CurrentEmotionalStatus,
                TagsList.ConvertAll(tag => tag.Name));
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
            return HashCode.Combine(Id);
        }
    }
}