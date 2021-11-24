using SocialNetwork.core.model.shared;
using System;
using System.Text.RegularExpressions;

namespace SocialNetwork.core.model.players.domain
{
    public class Name : IValueObject
    {
        private const string ShortNameRegex = "^[a-zA-Z0-9 ]*$";

        private const string FullNameRegex = "^[a-zA-Z0-9 ]*$";

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
                ShortName = shortName.Trim(); // To remove unnecessary empty spaces 
                FullName = fullName.Trim();
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
            return new Regex(ShortNameRegex).IsMatch(shortName)
                   && shortName.Length > 0;
        }

        public static bool IsFullNameValid(string fullName)
        {
            return new Regex(FullNameRegex).IsMatch(fullName)
                   && fullName.Length > 0;
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

            Name otherName = (Name) obj;
            return otherName.FullName.ToLower().Equals(FullName.ToLower());
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, ShortName);
        }
    }
}