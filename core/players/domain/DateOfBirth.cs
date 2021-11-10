using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.players.domain
{
    public class DateOfBirth : IValueObject
    {
        private static readonly int minimumAge = 16; // In years

        public DateTime Date { get; }

        protected DateOfBirth()
        {
            // for ORM
        }

        public DateOfBirth(int year, int month, int day)
        {
            if (IsValid(year))
                this.Date = new DateTime(year, month, day);
            else
                throw new BusinessRuleValidationException("Minimum age not respected");
        }

        public static bool IsValid(int year)
        {
            return (DateTime.Now.Year - year >= minimumAge);
        }

        public static DateOfBirth ValueOf(int year, int month, int day)
        {
            return new(year, month, day);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(DateOfBirth))
                return false;

            DateOfBirth otherDateOfBirth = (DateOfBirth)obj;

            return otherDateOfBirth.Date.Equals(this.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Date);
        }
    }
}
