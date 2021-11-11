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

        public Profile Profile { get; private set; }

        public List<MissionId> Missions { get; private set; }

        public List<RelationshipId> RelationShips { get; private set; }

        protected Player()
        {
            // for ORM
        }

        protected Player(PlayerId id, Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile,
            LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth,
            List<MissionId> missions, List<RelationshipId> relationships, Profile profile)
        {
            this.Id = id;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Missions = missions;
            this.RelationShips = relationships;
            this.Profile = profile;
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth, Profile profile)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Profile = profile;

            this.Missions = new();
            this.RelationShips = new();
        }

        public void LinkFacebook(FacebookProfile facebookProfile)
        {
            this.FacebookProfile = facebookProfile;
        }

        public void LinkLinkedin(LinkedinProfile linkedinProfile)
        {
            this.LinkedinProfile = linkedinProfile;
        }

        private void CreateProfile(Name name)
        {
            this.Profile = new(name);
        }

        public bool AssignTag(Tag newTag)
        {
            return this.Profile.AddTag(newTag);
        }

        public bool RemoveTag(Tag tagToRemove)
        {
            return this.Profile.RemoveTag(tagToRemove);
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
            if (this.RelationShips.Contains(relationshipId))
                return false;

            this.RelationShips.Add(relationshipId);
            return true;
        }

        public PlayerDto ToDto()
        {
            List<string> missions = new();
            foreach (MissionId nMission in Missions)
                missions.Add(nMission.Value);

            List<string> relationships = new();
            foreach (RelationshipId nRelationship in RelationShips)
                relationships.Add(nRelationship.Value);

            return new PlayerDto(this.Email.EmailAddress, this.PhoneNumber.Number,
                this.FacebookProfile.FacebookProfileLink, this.LinkedinProfile.LinkedinProfileLink,
                this.DateOfBirth.Date, this.Profile.ToDto(), missions, relationships);
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