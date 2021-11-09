using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.players.domain
{
    [Owned]
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
    }
}
