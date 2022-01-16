using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class NetworkFromPlayerPerspectiveDto
    {
        public string PlayerId { get; set; }
        
        public string PlayerName { get; set; }

        public string PlayerEmail { get; set; }

        public string EmotionalStatus { get; set; }

        public int? RelationshipStrength { get; set; }

        public List<string> RelationshipTags { get; set; }

        public List<NetworkFromPlayerPerspectiveDto> Relationships { get; set; }
    }
}