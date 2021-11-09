using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.missions.domain
{
    public enum MissionDifficultyEnum
    {
        Easy,
        Medium,
        Hard
    }

    [Owned]
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
    }
}
