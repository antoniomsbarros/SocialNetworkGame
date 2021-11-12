using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.missions.domain
{
    public class Mission : Entity<MissionId>
    {
        public PlayerId Player { get; private set; }
        public MissionStatus Status { get; private set; }

        public MissionDifficulty Difficulty { get; private set; }

        public PlayerId ObjectivePlayer { get; private set; }

        protected Mission()
        {
            // for ORM
        }

        protected Mission(MissionId id, PlayerId player, MissionStatus status, MissionDifficulty difficulty,
            Player objectivePlayer)
        {
            this.Id = id;
            this.Player = player;
            this.Status = status;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer.Id;
        }

        public Mission(PlayerId player, MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new MissionId(Guid.NewGuid());
            this.Player = player;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer.Id;
            this.Status = new(MissionStatusEnum.In_progress); // status for omission
        }

        public Mission(PlayerId player, MissionStatus status, MissionDifficulty difficulty, Player objectivePlayer)
        {
            this.Id = new MissionId(Guid.NewGuid());
            this.Player = player;
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

            Mission otherMission = (Mission) obj;

            return otherMission.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id);
        }
    }
}