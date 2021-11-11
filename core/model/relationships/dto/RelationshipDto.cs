using System;
using System.Collections.Generic;
using lapr5_3dg.DTO;
using SocialNetwork.core.model.players.dto;

namespace SocialNetwork.DTO
{
    public class RelationshipDto
    {
        public string id {get; set; }
        public string player { get; set; }
        public int connection { get; set; }
        public List<string> tags { get; set; }
        public RelationshipDto(string id, string player, int connection, List<string> tags)
        {
            this.id = id;
            this.player = player;
            this.connection = connection;
            this.tags = tags;
        }
    }
}