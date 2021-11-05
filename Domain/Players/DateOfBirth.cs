using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Players
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
