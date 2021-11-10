using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.missions.domain
{

    public class Mission : Entity<MissionId>
    {
        public MissionStatus Status { get; private set; }

        public MissionDifficulty Difficulty { get; private set; }

        public PlayerId ObjectivePlayer { get; private set; }

        protected Mission()
        {
            // for ORM
        }

        protected Mission(MissionId id, MissionStatus status, MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = id;
            this.Status = status;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer.Id;
        }

        public Mission(MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new MissionId(Guid.NewGuid());
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer.Id;
            this.Status = new(MissionStatusEnum.In_progress); // status for omission
        }

        public Mission(MissionStatus status, MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new MissionId(Guid.NewGuid());
            this.Status = status;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer.Id;
        }

        public void ChangeStatusTo(MissionStatus newStatus)
        {
            this.Status = newStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Mission))
                return false;

            Mission otherMission = (Mission)obj;

            return otherMission.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}