using Microsoft.EntityFrameworkCore;
using System;

namespace SocialNetwork.core.shared
{
    [Owned]
    public class CreationDate : IValueObject
    {

        public DateTime Date { get; }
        public CreationDate()
        {
            this.Date = new DateTime();
        }

        public CreationDate(int year, int month, int day)
        {
            this.Date = new DateTime(year, month, day);
        }

    }
}
