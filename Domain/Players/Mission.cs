using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Players
{

    public class Mission : Entity<MissionId>
    {
        public MissionStatus Status { get; private set; }

        public MissionDifficulty Difficulty { get; private set; }

        public PlayerId ObjectivePlayer { get; private set; }

        public Mission(MissionDifficulty difficulty, PlayerId objectivePlayer)
        {
            this.Status = new(MissionStatusEnum.Suspended);
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer;
        }

        public Mission(MissionStatus status, MissionDifficulty difficulty, PlayerId objectivePlayer)
        {
            this.Status = status;
            this.Difficulty = difficulty;
            this.ObjectivePlayer = objectivePlayer;
        }

        public void ChanceStatusTo(MissionStatus newStatus)
        {
            this.Status = newStatus;
        }
    }
}