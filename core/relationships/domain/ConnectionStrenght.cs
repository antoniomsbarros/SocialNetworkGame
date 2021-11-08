using SocialNetwork.core.shared;

namespace SocialNetwork.core.relationships.domain
{
    public class ConnectionStrenght : IValueObject
    {
        public int Strenght { get; }

        public ConnectionStrenght(int strenght)
        {
            this.Strenght = strenght; // There's a min and/or max?
        }

    }
}
