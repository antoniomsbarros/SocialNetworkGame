using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;

using System;
namespace LEI_21s5_3dg_41.Domain.Players
{
    public class RelationShip : Entity<RelationShipId>
    {
        public int relationStrenght { get;  private set; }
        public int connectionStrenght { get;  private set; }

        public PlayerId playerId { get;  private set; }

        public List<PlayerId> friends { get;  private set; }

        public RelationShip (int relationStrenght, int connectionStrenght, PlayerId playerId, List<PlayerId> friends){
            this.relationStrenght=relationStrenght;
            this.connectionStrenght=connectionStrenght;
            this.playerId=playerId;
            this.friends=friends;
        }

         
    }
}    