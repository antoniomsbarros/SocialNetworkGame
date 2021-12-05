using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.players.domain
{
    public class DateOfBirth : IValueObject
    {
        private const int MinimumAge = 16; // In years

        public DateTime Date { get; }

        protected DateOfBirth()
        {
            // for ORM
        }

        public DateOfBirth(int year, int month, int day)
        {
            if (HasMinimumAge(year))
                Date = new DateTime(year, month, day);
            else
                throw new BusinessRuleValidationException("Minimum age not respected");
        }

        public DateOfBirth(DateTime date)
        {
            if (HasMinimumAge(date.Year))
                Date = date;
            else
                throw new BusinessRuleValidationException("Minimum age not respected");
        }

        public static bool HasMinimumAge(int year)
        {
            return DateTime.Now.Year - year >= MinimumAge;
        }

        public static DateOfBirth ValueOf(int year, int month, int day)
        {
            return new(year, month, day);
        }

        public static DateOfBirth ValueOf(DateTime date)
        {
            
            return new(date);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(DateOfBirth))
                return false;

            DateOfBirth otherDateOfBirth = (DateOfBirth) obj;

            return otherDateOfBirth.Date.Equals(Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date);
        }
    }
}