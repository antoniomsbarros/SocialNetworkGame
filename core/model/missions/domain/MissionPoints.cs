using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.missions.domain
{
    public class MissionPoints : IValueObject
    {
        private const int DefaultPoints = 0;
        public int Points { get; }

        public MissionPoints()
        {
            this.Points = DefaultPoints;
        }

        public MissionPoints(int points)
        {
            this.Points = points; // there's a min/max points? (bool IsValid)
        }

        public static MissionPoints ValueOf(int points)
        {
            return new(points);
        }

        public MissionPoints IncrementPoints(int points)
        {
            return new(this.Points + points);
        }

        public MissionPoints DecrementPoints(int points)
        {
            return new(this.Points - points);
        }
    }
}