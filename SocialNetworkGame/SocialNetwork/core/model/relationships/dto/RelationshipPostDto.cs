using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class RelationshipPostDto
    {
        public string playerDest { get; set; }

        public string playerOrig { get; set; }
        public int connection { get; set; }
        public List<string> tags { get; set; }
        public RelationshipPostDto( string playerDest, string playerOrig, int connection, List<string> tags)
        {
            this.playerDest = playerDest;
            this.playerOrig = playerOrig;
            this.connection = connection;
            this.tags = tags;
        }
    }
}
