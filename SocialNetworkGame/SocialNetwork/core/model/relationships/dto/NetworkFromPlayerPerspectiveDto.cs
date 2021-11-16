using System.Collections.Generic;

namespace SocialNetwork.DTO
{
    public class NetworkFromPlayerPerspectiveDto
    {
        public string RelationshipId { get; set; }
        public int ?RelationshipStrength { get; set; }
        public List<string> RelationshipTags { get; set; }

        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public List<string> PlayerTags { get; set; }
        public List<NetworkFromPlayerPerspectiveDto> Relationships { get; set; }
    }
}