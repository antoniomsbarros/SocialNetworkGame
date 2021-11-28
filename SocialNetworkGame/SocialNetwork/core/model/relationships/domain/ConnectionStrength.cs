using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.relationships.domain
{
    public class ConnectionStrength : IValueObject
    {
        private const int MinStrength = 1;

        private const int MaxStrength = 100;

        public int Strength { get; }

        protected ConnectionStrength()
        {
            // for ORM
        }

        public ConnectionStrength(int strength)
        {
            if (IsValid(strength))
                Strength = strength;
            else
                throw new BusinessRuleValidationException(
                    $"The connection strength's value must be between {MinStrength} and {MaxStrength}.");
        }

        public static bool IsValid(int strength)
        {
            return strength is >= MinStrength and <= MaxStrength;
        }

        public static ConnectionStrength ValueOf(int strength)
        {
            return new(strength);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(ConnectionStrength))
                return false;

            ConnectionStrength otherConnectionStrength = (ConnectionStrength) obj;

            return otherConnectionStrength.Strength.Equals(otherConnectionStrength.Strength);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Strength);
        }
    }
}