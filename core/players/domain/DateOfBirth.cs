using SocialNetwork.core.shared;
using System;

namespace SocialNetwork.core.players.domain
{
    public class DateOfBirth : IValueObject
    {
        private static readonly DateTime miniumAge = DateTime.Now;

        public DateTime Date { get; }

        public DateOfBirth(int year, int month, int day)
        {
            if (IsValid(year, month, day))
                this.Date = new DateTime(year, month, day);
            else
                throw new BusinessRuleValidationException("Minimum age not respected");
        }

        public static bool IsValid(int year, int month, int day)
        {
            return new DateTime(year, month, day).CompareTo(miniumAge) < 0;
        }


    }
}
