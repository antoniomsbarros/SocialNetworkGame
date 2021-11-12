using System;
using System.Collections.Generic;
using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.domain;
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

        public List<MissionId> Missions { get; private set; }

        public List<RelationshipId> Relationships { get; private set; }

        //TODO Enquanto nao tiver o PlayerDTO completo
        protected Player()
        {
            // for ORM
        }

        protected Player(PlayerId id, Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth, Name name, EmotionalStatus emotionalStatus,
            List<MissionId> missions, List<RelationshipId> relationships)
        {
            this.Id = id;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Name = name;
            this.EmotionalStatus = emotionalStatus;
            this.Missions = new(missions);
            this.Relationships = new(relationships);
        }

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile,
            DateOfBirth dateOfBirth, Name name, EmotionalStatus emotionalStatus)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new();
            this.Relationships = new();
            this.Name = name;
            this.EmotionalStatus = emotionalStatus;
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new();
            this.Relationships = new();

            this.FacebookProfile = new();
            this.LinkedinProfile = new();
            this.EmotionalStatus = new(EmotionalStatusEnum.NotSpecified);
        }

        public void LinkFacebook(FacebookProfile facebookProfile)
        {
            this.FacebookProfile = facebookProfile;
        }

        public void LinkLinkedin(LinkedinProfile linkedinProfile)
        {
            this.LinkedinProfile = linkedinProfile;
        }

        public bool GiveMission(MissionId mission)
        {
            if (this.Missions.Contains(mission))
                return false;

            this.Missions.Add(mission);
            return true;
        }

        public bool RemoveMission(MissionId mission)
        {
            return this.Missions.Remove(mission);
        }

        public bool StablishRelationShip(RelationshipId relationshipId)
        {
            if (this.Relationships.Contains(relationshipId))
                return false;

            this.Relationships.Add(relationshipId);

            return true;
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

        public void SetNameTo(Name newName)
        {
            this.Name = newName;
        }

        public void SetEmotionalStatusTo(EmotionalStatus emotionalStatus)
        {
            this.EmotionalStatus = emotionalStatus;
        }

        public PlayerDto ToDto()
        {
            return new PlayerDto(this.Id.Value, this.Email.EmailAddress, this.PhoneNumber.Number,
                this.FacebookProfile.FacebookProfileLink, this.LinkedinProfile.LinkedinProfileLink,
                this.DateOfBirth.Date, Missions.ConvertAll(mission => mission.Value),
                Relationships.ConvertAll(relationship => relationship.Value)
                , this.Name.ShortName, this.Name.FullName,
                this.EmotionalStatus.CurrentEmotionalStatus);
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