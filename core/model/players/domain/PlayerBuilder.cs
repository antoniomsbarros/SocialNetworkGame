using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.relationships.domain;

namespace SocialNetwork.core.model.players.domain
{
    public class PlayerBuilder : IDomainBuilder<Player>
    {
        private Player _player;

        private Email _email;
        private PhoneNumber _phoneNumber;
        private DateOfBirth _dateOfBirth;
        private Profile _profile;
        private List<MissionId> _missions;
        private List<RelationshipId> _relationShips;

        private FacebookProfile _facebookProfile;
        private LinkedinProfile _linkedinProfile;

        public PlayerBuilder()
        {
            // empty
        }

        public PlayerBuilder WithEmail(Email email)
        {
            this._email = email;
            return this;
        }

        public PlayerBuilder WithPhoneNumber(PhoneNumber phoneNumber)
        {
            this._phoneNumber = phoneNumber;
            return this;
        }

        public PlayerBuilder WithDateOfBirth(DateOfBirth dateOfBirth)
        {
            this._dateOfBirth = dateOfBirth;
            return this;
        }

        public PlayerBuilder WithProfile(Profile profile)
        {
            this._profile = profile;
            return this;
        }

        public PlayerBuilder WithFacebookProfile(FacebookProfile facebookProfile)
        {
            this._facebookProfile = facebookProfile;
            return this;
        }

        public PlayerBuilder WithLinkedinProfile(LinkedinProfile linkedinProfile)
        {
            this._linkedinProfile = linkedinProfile;
            return this;
        }

        public PlayerBuilder WithMissions()
        {
            this._missions = new();
            return this;
        }

        public PlayerBuilder AddMission(MissionId mission)
        {
            this._missions.Add(mission);
            return this;
        }

        public PlayerBuilder WithRelationships(RelationShip relationShip)
        {
            this._relationShips = new();
            return this;
        }

        public PlayerBuilder AddRelationship(RelationshipId relationShip)
        {
            this._relationShips.Add(relationShip);
            return this;
        }

        public Player Build()
        {
            Player player = BuildOrIgnore();
            this._player = null;
            return player;
        }

        public Player BuildOrIgnore()
        {
            if (this._player != null)
                return this._player;
            else
            {
                this._player = new(this._email, this._phoneNumber, this._dateOfBirth, this._profile);

                if (this._facebookProfile != null)
                    this._player.LinkFacebook(this._facebookProfile);

                if (this._linkedinProfile != null)
                    this._player.LinkLinkedin(this._linkedinProfile);

                foreach (var nMission in _missions)
                    this._player.GiveMission(nMission);

                foreach (var nRelationship in _relationShips)
                    this._player.StablishRelationShip(nRelationship);

                return this._player;
            }
        }
    }
}