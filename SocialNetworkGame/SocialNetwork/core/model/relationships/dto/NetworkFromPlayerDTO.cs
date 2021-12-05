using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class NetworkFromPLayerDTO
    {
        public string playerOriginEmail {get; set;}
        public string playerDestEmail {get; set;}
        
        public int RelationshipStrengthOrigin {get; set;}
        public int RelationshipStrengthDest {get; set;}
        
        public List<string> RelationshipTagsOrigin { get; set; }
        public List<string> PlayerTagsDest { get; set; }
        
        public List<NetworkFromPLayerDTO> Relationships { get; set; }
    }
}