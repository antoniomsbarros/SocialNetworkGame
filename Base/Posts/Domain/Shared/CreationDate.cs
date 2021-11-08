using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class CreationDate : IValueObject
    {

        public DateTime Date { get; }

        public CreationDate(int year, int month, int day)
        {
            if (IsValid(year, month, day))
                this.Date = new DateTime(year, month, day);
            else
                throw new BusinessRuleValidationException("Date not correct");
        }

        public static bool IsValid(int year, int month, int day)
        {
            return new DateTime(year, month, day) != null;
        }


    }
}
