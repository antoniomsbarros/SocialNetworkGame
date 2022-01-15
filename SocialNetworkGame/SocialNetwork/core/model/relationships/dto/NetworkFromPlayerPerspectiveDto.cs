using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class NetworkFromPlayerPerspectiveDto
    {
        public string PlayerId { get; set; }

        public string PlayerName { get; set; }

        public int? RelationshipStrengthOrig { get; set; } // A --> B : stores the strength of the relation in this direction

        public int? RelationshipStrengthDest { get; set; } // A <-- B : stores the strength of the relation in opposite direction of the previous
        public string emotionalStatus {get; set;} 
        public List<string> RelationshipTagsOrig { get; set; }

        public List<string> RelationshipTagsDest { get; set; }

        /* This seems unnecessary
         
        public List<string> PlayerTags { get; set; }

        */
        public List<NetworkFromPlayerPerspectiveDto> Relationships { get; set; }
    }
}