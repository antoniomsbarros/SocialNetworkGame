using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public enum MissionStatusEnum
    {
        Active,
        Canceled,
        Completed,
        In_progress,
        Suspended
    }

    public class MissionStatus : IValueObject
    {
        public MissionStatusEnum CurrentStatus { get; }

        public MissionStatus(MissionStatusEnum status)
        {
            this.CurrentStatus = status;
        }

    }
}
