using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.relationships.domain
{
    public class ConnectionStrenght : IValueObject
    {
        private static readonly int minStrenght = 0;

        private static readonly int maxStrenght = 100;

        public int Strenght { get; }

//TODO Enquanto nao tiver o PlayerDTO completo
        public ConnectionStrenght()
        {
            // for ORM
        }

        public ConnectionStrenght(int strenght)
        {
            if (IsValid(strenght))
                this.Strenght = strenght;
            else
                throw new BusinessRuleValidationException(
                    string.Format("The connection strenght's value must be between {0} and {1}.", minStrenght, maxStrenght));
        }

        public static bool IsValid(int strenght)
        {
            return (strenght >= minStrenght && strenght <= maxStrenght);
        }

        public static ConnectionStrenght ValueOf(int strenght)
        {
            return new(strenght);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(ConnectionStrenght))
                return false;

            ConnectionStrenght otherConnectionStrenght = (ConnectionStrenght)obj;

            return otherConnectionStrenght.Strenght.Equals(otherConnectionStrenght.Strenght);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Strenght);
        }
    }
}
