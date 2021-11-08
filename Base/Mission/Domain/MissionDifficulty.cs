using LEI_21s5_3dg_41.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LEI_21s5_3dg_41.Domain.Players
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
