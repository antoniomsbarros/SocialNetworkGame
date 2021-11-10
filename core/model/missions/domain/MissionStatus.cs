using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.missions.domain
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

        protected MissionStatus()
        {
            // for ORM
        }

        public MissionStatus(MissionStatusEnum status)
        {
            this.CurrentStatus = status;
        }

        public static MissionStatus ValueOf(MissionStatusEnum status)
        {
            return new(status);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(MissionStatus))
                return false;

            MissionStatus otherMissionStatus = (MissionStatus)obj;

            return otherMissionStatus.CurrentStatus.Equals(this.CurrentStatus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.CurrentStatus);
        }
    }
}
