using System;
using System.Collections.Generic;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.relationships.domain;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class Player : Entity<PlayerId>, IAggregateRoot
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

        public Player(Email email, PhoneNumber phoneNumber, FacebookProfile facebookProfile, LinkedinProfile linkedinProfile, DateOfBirth dateOfBirth,
            Name name, List<Tag> tagsList)
        {
            this.Id = new(Guid.NewGuid());
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.FacebookProfile = facebookProfile;
            this.LinkedinProfile = linkedinProfile;
            this.DateOfBirth = dateOfBirth;
            CreateProfile(name, tagsList);
            this.Missions = new();
            this.RelationShips = new();
        }

        private void CreateProfile(Name name, List<Tag> tagsList)
        {
            this.Profile = new(name, tagsList);
        }

        // Add and remove Missions and relationships
    }
}
