using System;
using System.Collections.Generic;
using lapr5_3dg.DTO;
using SocialNetwork.core.model.players.dto;

namespace SocialNetwork.DTO
{
    public class RelationshipDto
    {
        public string id {get; set; }
        public string playerDest { get; set; }
        public string playerOrig { get; set; }
        public int connection { get; set; }
        public List<string> tags { get; set; }
        public RelationshipDto(string id, string playerDest, string playerOrig, int connection, List<string> tags)
        {
            this.id = id;
            this.playerDest = playerDest;
            this.playerOrig = playerOrig;
            this.connection = connection;
            this.tags = tags;
        }
    }
}