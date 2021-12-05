using System;
using System.Collections.Generic;

namespace SocialNetwork.core.model.players.dto
{
    public class UpdatePlayerDto
    {
        public string email;
        public string phoneNumber;
        public string facebookProfile;
        public string linkedinProfile;
        public DateTime? dateOfBirth;
        public string shortName; // Name
        public string fullName; // Name
        public List<string> tags;

        public UpdatePlayerDto()
        {
            // empty
        }
    }
}