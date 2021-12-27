using SocialNetwork.core.model.shared;

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

        public PlayerBuilder()
        {
            // empty
        }

        public PlayerBuilder WithEmail(Email email)
        {
            _email = email;
            return this;
        }

        public PlayerBuilder WithPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumber = phoneNumber;
            return this;
        }

        public PlayerBuilder WithDateOfBirth(DateOfBirth dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            return this;
        }

        public PlayerBuilder WithName(Name name)
        {
            _name = name;
            return this;
        }

        public PlayerBuilder WithEmotionalStatus(EmotionalStatus emotionalStatus)
        {
            _emotionalStatus = emotionalStatus;
            return this;
        }

        public PlayerBuilder WithFacebookProfile(FacebookProfile facebookProfile)
        {
            _facebookProfile = facebookProfile;
            return this;
        }

        public PlayerBuilder WithLinkedinProfile(LinkedinProfile linkedinProfile)
        {
            _linkedinProfile = linkedinProfile;
            return this;
        }

        public Player Build()
        {
            Player player = BuildOrIgnore();
            _player = null;
            return player;
        }

        public Player BuildOrIgnore()
        {
            if (_player != null)
                return _player;
            else
            {
                _player = new(_email, _phoneNumber, _dateOfBirth);

                if (_facebookProfile != null)
                    _player.LinkFacebook(_facebookProfile);

                if (_linkedinProfile != null)
                    _player.LinkLinkedin(_linkedinProfile);

                if (_name != null)
                    _player.SetName(_name);

                if (_emotionalStatus != null)
                    _player.SetEmotionalStatusTo(_emotionalStatus);

                return _player;
            }
        }
    }
}