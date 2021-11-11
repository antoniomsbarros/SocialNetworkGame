using System.Collections.Generic;

namespace SocialNetwork.core.model.relationships.dto
{
    public class RelationshipPostDto
    {
        public string player { get; set; }
        public int connection { get; set; }
        public List<string> tags { get; set; }
        public RelationshipPostDto( string player, int connection, List<string> tags)
        {
            this.player = player;
            this.connection = connection;
            this.tags = tags;
        }
    }
}
