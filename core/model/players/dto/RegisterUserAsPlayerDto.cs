using System;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.players.dto
{
    public class RegisterUserAsPlayerDto
    {
        public string email;
        public string password;
        public string phoneNumber;
        public string facebookProfile;
        public string linkedinProfile;
        public DateTime dateOfBirth;
        public string shortName;
        public string fullName;
        public EmotionalStatusEnum emotionalStatus;

        public RegisterUserAsPlayerDto(string email, string password, string phoneNumber, string facebookProfile,
            string linkedinProfile,
            DateTime dateOfBirth, string shortName, string fullName, EmotionalStatusEnum emotionalStatus)
        {
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.facebookProfile = facebookProfile;
            this.linkedinProfile = linkedinProfile;
            this.dateOfBirth = dateOfBirth;
            this.shortName = shortName;
            this.fullName = fullName;
            this.emotionalStatus = emotionalStatus;
        }

        public RegisterUserAsPlayerDto()
        {
            // empty
        }
    }
}