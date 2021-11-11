using System;
using System.Collections.Generic;
using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class Player : Entity<PlayerId>, IAggregateRoot
    {
        public Email Email { get; private set; } // SystemUserId

        public PhoneNumber PhoneNumber { get; private set; }

        public FacebookProfile FacebookProfile { get; private set; }

        public LinkedinProfile LinkedinProfile { get; private set; }

        public DateOfBirth DateOfBirth { get; private set; }

        public Profile Profile { get; private set; }

        public List<MissionId> Missions { get; private set; }

        public List<RelationshipId> Relationships { get; private set; }

        //TODO Enquanto nao tiver o PlayerDTO completo
        public Player()
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
            this.Missions = new(missions);
            this.Relationships = new(relationships);
            this.Profile = profile;
        }

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile, LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth,
            Name name)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new();
            this.Relationships = new();
            CreateProfile(name);
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth, Name name)
        {
            this.Id = new PlayerId(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;

            this.Missions = new();
            this.Relationships = new();
            CreateProfile(name);
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

        public void StartMission(MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Missions.Add(new Mission(MissionStatus.ValueOf(MissionStatusEnum.In_progress), difficulty,
                objectivePlayer).Id);
        }

        // Finish / Pause Mission
        // ...
        public bool StablishRelationShip(RelationshipId relationshipId)
        {
            if (this.Relationships.Contains(relationshipId))
                return false;

            this.Relationships.Add(relationshipId);

            return true;
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