using System;
using System.Collections.Generic;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.relationships.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class Player : Entity<long>, IAggregateRoot
    {
        public Email Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public FacebookProfile FacebookProfile { get; private set; }

        public LinkedinProfile LinkedinProfile { get; private set; }

        public DateOfBirth DateOfBirth { get; private set; }

        public Profile Profile { get; private set; }

        public List<Mission> Missions { get; private set; }

        public List<RelationShip> RelationShips { get; private set; }

        protected Player()
        {
            // for ORM
        }

        protected Player(long id, Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile, LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth,
            List<Mission> missions, List<RelationShip> relationships, Profile profile)
        {
            this.Id = id;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new(missions);
            this.RelationShips = new(relationships);
            this.Profile = profile;
        }

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile, LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth,
            Name name)
        {
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new();
            this.RelationShips = new();
            CreateProfile(name);
        }

        public Player(Email email, PhoneNumber phoneNumber, DateOfBirth dateOfBirth, Name name)
        {
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Missions = new();
            this.RelationShips = new();
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
            this.Missions.Add(new(MissionStatus.ValueOf(MissionStatusEnum.In_progress), difficulty, objectivePlayer));
        }

        // Finish / Pause Mission
        // ...

        public bool CreateRelationShipWith(Player player, ConnectionStrenght connectionStrenght, params Tag[] tags)
        {
            if (this.RelationShips.Contains(new RelationShip(player)))
                return false;

            this.RelationShips.Add(new RelationShip(player));
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Player))
                return false;

            Player otherPlayer = (Player)obj;

            return otherPlayer.Email.Equals(this.Email);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Email);
        }
    }
}
