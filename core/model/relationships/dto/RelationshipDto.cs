using System;
using System.Collections.Generic;
using lapr5_3dg.DTO;

namespace SocialNetwork.DTO
{
    public class RelationshipDto
    {
        public string id {get; set; }
        public PlayerDto player { get; set; }
        public ConnectionStrenghtDto connection { get; set; }
        public List<string> tags { get; set; }
        public RelationshipDto(string id, PlayerDto player, ConnectionStrenghtDto connection, List<string> tags)
        {
            this.id = id;
            this.player = player;
            this.connection = connection;
            this.tags = tags;
        }
    }
}