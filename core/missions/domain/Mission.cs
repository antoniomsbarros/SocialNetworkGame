using SocialNetwork.core.players.domain;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.missions.domain
{

    public class Mission : Entity<MissionId>
    {
        public MissionStatus Status { get; private set; }

        public MissionDifficulty Difficulty { get; private set; }

        public Player ObjectivePlayer { get; private set; }

        protected Mission()
        {
            // for ORM
        }

        public Mission(MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new(Guid.NewGuid());
            this.Status = new(MissionStatusEnum.Suspended);
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer;
        }

        public Mission(MissionStatus status, MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new(Guid.NewGuid());
            this.Status = status;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer;
        }

        public void ChangeStatusTo(MissionStatus newStatus)
        {
            this.Status = newStatus;
        }
    }
}