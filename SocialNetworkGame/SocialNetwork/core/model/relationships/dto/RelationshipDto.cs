using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class RelationshipDto
    {
        public string id { get; set; }
        public string playerDest { get; set; }
        public string playerDestEmail { get; set; }
        public string playerOrigEmail { get; set; }
        public string playerOrig { get; set; }
        public int connectionStrength { get; set; }
        public List<string> tags { get; set; }

        public RelationshipDto(string id, string playerDest, string playerOrig, int connectionStrength, List<string> tags)
        {
            this.id = id;
            this.playerDest = playerDest;
            this.playerOrig = playerOrig;
            this.connectionStrength = connectionStrength;
            this.tags = tags;
        }

        public RelationshipDto(string id, string playerDest, string playerDestEmail, string playerOrig, int connectionStrength, List<string> tags)
        {
            this.playerDestEmail = playerDestEmail;
            this.id = id;
            this.playerDest = playerDest;
            this.playerOrig = playerOrig;
            this.connectionStrength = connectionStrength;
            this.tags = tags;
        }
        
        public RelationshipDto()
        {
            // empty
        }
    }
}