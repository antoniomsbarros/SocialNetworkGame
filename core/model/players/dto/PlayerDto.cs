using System;
using System.Collections.Generic;

namespace SocialNetwork.core.model.players.dto
{
    public class PlayerDto
    {
        public string email;
        public string phoneNumber;
        public string facebookProfile;
        public string linkedinProfile;
        public DateTime dateOfBirth;
        public ProfileDto profile;
        public List<string> missions;
        public List<string> relationships;

        public PlayerDto(string email, string phoneNumber, string facebookProfile, string linkedinProfile,
            DateTime dateOfBirth,
            ProfileDto profile, List<string> missions, List<string> relationships)
        {
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.facebookProfile = facebookProfile;
            this.linkedinProfile = linkedinProfile;
            this.profile = profile;
            this.missions = missions;
            this.relationships = relationships;
        }

        public PlayerDto()
        {
            // empty
        }
    }
}