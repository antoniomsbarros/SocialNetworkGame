using SocialNetwork.core.shared;

namespace SocialNetwork.core.missions.domain
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

        public MissionDifficulty(MissionDifficultyEnum difficulty)
        {
            this.Difficulty = difficulty;
        }
    }
}
