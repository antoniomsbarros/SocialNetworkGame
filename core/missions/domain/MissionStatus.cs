using SocialNetwork.core.shared;

namespace SocialNetwork.core.missions.domain
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
