using System;
using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.players.dto
{
    public class UpdatePlayerDto
    {
        public string id;
        public string email;
        public string phoneNumber;
        public string facebookProfile;
        public string linkedinProfile;
        public DateTime dateOfBirth;
        public string shortName; // Name
        public string fullName; // Name
        public List<string> ?tags;

        public UpdatePlayerDto()
        {
            // empty
        }
    }
}