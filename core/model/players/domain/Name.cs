using SocialNetwork.core.model.shared;
using System;

namespace SocialNetwork.core.model.players.domain
{
    public class Name : IValueObject
    {
        public string ShortName { get; }
        public string FullName { get; }

        protected Name()
        {
            // for ORM
        }

        public Name(string shortName, string fullName)
        {
            if (IsFullNameValid(fullName) && IsShortNameValid(shortName))
            {
                this.ShortName = shortName;
                this.FullName = fullName;
            }
            else if (IsFullNameValid(fullName))
                throw new BusinessRuleValidationException("Short name invalid");
            else if (IsShortNameValid(shortName))
                throw new BusinessRuleValidationException("Full name invalid");
            else
                throw new BusinessRuleValidationException("Short and full name invalid");
        }

        public static bool IsShortNameValid(string shortName)
        {
            return shortName.Length > 0;
        }

        public static bool IsFullNameValid(string fullName)
        {
            return fullName.Length > 0;
        }

        public static Name ValueOf(string shortName, string fullName)
        {
            return new(shortName, fullName);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Name))
                return false;

            Name otherName = (Name)obj;

            return otherName.FullName.Trim().ToLower().Equals(
                this.FullName.Trim().ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.FullName, this.ShortName);
        }
    }
}
