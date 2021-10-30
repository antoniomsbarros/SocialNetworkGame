using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;

using System;

namespace LEI_21s5_3dg_41.Domain.Player
{
public enum MissionStatus{
    Active,
    Canceled,
    Completed,
    In_progress
}

    public class Mission : Entity<MissionId>
    {
        public MissionStatus missionStatus { get;  private set; }
        public Profile profiledestinion { get;  private set; }
        public int dificulty { get;  private set; }

        public Mission(MissionStatus missionStatus, int dificulty, Profile profiledestinion){
            this.missionStatus=missionStatus;
            this.dificulty=dificulty;
            this.profiledestinion=profiledestinion;
        }

    }
}