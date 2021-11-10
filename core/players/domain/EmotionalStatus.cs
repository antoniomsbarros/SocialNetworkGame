using SocialNetwork.core.shared;

namespace SocialNetwork.core.players.domain
{
    public class EmotionalStatus : Entity<long>
    {

        // protected 
        public EmotionalStatus()
        {
            // for ORM
        }

        protected EmotionalStatus(long id)
        {
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}