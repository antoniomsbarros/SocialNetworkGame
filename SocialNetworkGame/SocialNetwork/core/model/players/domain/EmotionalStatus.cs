using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class EmotionalStatus : IValueObject
    {
        public EmotionalStatusEnum CurrentEmotionalStatus { get; }

        public DateTime UpdateDate { get; }

        protected EmotionalStatus()
        {
            // for ORM
        }

        public EmotionalStatus(EmotionalStatusEnum emotionalStatus)
        {
            CurrentEmotionalStatus = emotionalStatus;
            UpdateDate = DateTime.Now;
        }

        public static EmotionalStatus ValueOf(EmotionalStatusEnum emotionalStatus)
        {
            return new(emotionalStatus);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(EmotionalStatus))
                return false;

            EmotionalStatus otherEmotionalStatus = (EmotionalStatus) obj;

            return otherEmotionalStatus.CurrentEmotionalStatus.Equals(CurrentEmotionalStatus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CurrentEmotionalStatus);
        }

        public override string ToString()
        {
            return CurrentEmotionalStatus + " - Updated At: " + UpdateDate;
        }
    }
}