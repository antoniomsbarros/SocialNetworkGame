using System;

namespace SocialNetwork.core.model.shared
{
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
        public CreationDate(string dateddMMyyyy)
        {
            Date = Convert.ToDateTime(dateddMMyyyy);
        }

        public static CreationDate ValueOf(int year, int month, int day)
        {
            return new(year, month, day);
        }

        public static CreationDate ValueOf()
        {
            return new();
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(CreationDate))
                return false;

            CreationDate otherCreationDate = (CreationDate)obj;

            return otherCreationDate.Date.Equals(this.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Date);
        }

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy");
        }
    }
}
