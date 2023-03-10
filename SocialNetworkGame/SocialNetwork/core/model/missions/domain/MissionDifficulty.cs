using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.missions.domain
{
    public enum MissionDifficultyEnum
    {
        Easy,
        Medium,
        Hard
    }

    public class MissionDifficulty : IValueObject
    {
        public MissionDifficultyEnum Difficulty { get; }

        protected MissionDifficulty()
        {
            // for ORM
        }

        public MissionDifficulty(MissionDifficultyEnum difficulty)
        {
            this.Difficulty = difficulty;
        }

        public static MissionDifficulty ValueOf(MissionDifficultyEnum difficulty)
        {
            return new(difficulty);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(MissionDifficulty))
                return false;

            MissionDifficulty otherMissionDifficulty = (MissionDifficulty)obj;

            return otherMissionDifficulty.Difficulty.Equals(this.Difficulty);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Difficulty);
        }
    }
}
