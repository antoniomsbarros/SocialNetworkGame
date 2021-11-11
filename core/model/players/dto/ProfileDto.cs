using System.Collections.Generic;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.model.players.dto
{
    public class ProfileDto
    {
        public string shortName; // Name
        public string fullName; // Name
        public EmotionalStatusEnum emotionalStatus;
        public List<string> tags;

        public ProfileDto(string shortName, string fullName, EmotionalStatusEnum emotionalStatus, List<string> tags)
        {
            this.shortName = shortName;
            this.fullName = fullName;
            this.emotionalStatus = emotionalStatus;
            this.tags = new(tags);
        }

        public ProfileDto()
        {
            // empty
        }
    }
}