using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.players.dto
{
    public class PlayerDto
    {
        public string id;
        public string email;
        public string phoneNumber;
        public string facebookProfile;
        public string linkedinProfile;
        public DateTime dateOfBirth;
        public string shortName; // Name
        public string fullName; // Name
        public string emotionalStatus;
        public List<string> tags;

        public PlayerDto(string id, string email, string phoneNumber, string facebookProfile, string linkedinProfile,
            DateTime dateOfBirth, string shortName, string fullName, EmotionalStatusEnum emotionalStatus,
            List<string> tags)
        {
            this.id = id;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.facebookProfile = facebookProfile;
            this.linkedinProfile = linkedinProfile;
            this.dateOfBirth = dateOfBirth;
            this.emotionalStatus = emotionalStatus.ToString();
            this.shortName = shortName;
            this.fullName = fullName;
            this.tags = new(tags);
        }

        public PlayerDto()
        {
            // empty
        }
    }
}