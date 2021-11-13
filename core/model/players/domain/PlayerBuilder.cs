using SocialNetwork.core.model.shared;
using System.Collections.Generic;

namespace SocialNetwork.core.model.players.domain
{
    public class PlayerBuilder : IDomainBuilder<Player>
    {
        private Player _player;

        private Email _email;
        private PhoneNumber _phoneNumber;
        private DateOfBirth _dateOfBirth;
        private Name _name;
        private EmotionalStatus _emotionalStatus;

        private FacebookProfile _facebookProfile;
        private LinkedinProfile _linkedinProfile;
        private List<Tag> _tagsList;

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

        public PlayerBuilder WithName(Name name)
        {
            this._name = name;
            return this;
        }

        public PlayerBuilder WithEmotionalStatus(EmotionalStatus emotionalStatus)
        {
            this._emotionalStatus = emotionalStatus;
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

        public PlayerBuilder AssociateTags()
        {
            this._tagsList = new();
            return this;
        }

        public PlayerBuilder AddTag(Tag tag)
        {
            if (!this._tagsList.Contains(tag))
                this._tagsList.Add(tag);

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
                this._player = new(_email, _phoneNumber, _dateOfBirth);

                if (this._facebookProfile != null)
                    this._player.LinkFacebook(_facebookProfile);

                if (this._linkedinProfile != null)
                    this._player.LinkLinkedin(_linkedinProfile);

                if (this._name != null)
                    this._player.ChangeName(_name);

                if (this._emotionalStatus != null)
                    this._player.SetEmotionalStatusTo(_emotionalStatus);

                foreach (Tag nTag in this._tagsList)
                    this._player.AssignTag(nTag);

                return this._player;
            }
        }
    }
}