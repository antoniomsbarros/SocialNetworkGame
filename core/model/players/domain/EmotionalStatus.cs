using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.players.domain
{
    public class EmotionalStatus : IValueObject
    {
        public EmotionalStatusEnum CurrentEmotionalStatus { get; }
        public DateTime lastUpdate {get; private set;}

        // protected 
        protected EmotionalStatus()
        {
            // for ORM
        }

        public EmotionalStatus(EmotionalStatusEnum emotionalStatus)
        {
            this.CurrentEmotionalStatus = emotionalStatus;
            this.lastUpdate = DateTime.Now;
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

            return otherEmotionalStatus.CurrentEmotionalStatus.Equals(this.CurrentEmotionalStatus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.CurrentEmotionalStatus);
        }
        
        public String ToString(){
            return this.CurrentEmotionalStatus + " - Last updated: " + this.lastUpdate.ToString();
        }
        
    }
}