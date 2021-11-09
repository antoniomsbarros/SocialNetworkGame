using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.relationships.domain
{
    [Owned]
    public class ConnectionStrenght : IValueObject
    {
        public int Strenght { get; }

        protected ConnectionStrenght()
        {
            // for ORM
        }
        public ConnectionStrenght(int strenght)
        {
            this.Strenght = strenght; // There's a min and/or max?
        }

    }
}
