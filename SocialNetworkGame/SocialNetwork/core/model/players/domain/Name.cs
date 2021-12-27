using SocialNetwork.core.model.shared;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.core.model.players.domain
{
    public class Name : IValueObject
    {
        private const string ShortNameRegex = "^.*$";

        private const string FullNameRegex = "^.*$";

        private const string DefaultShortName = "Not specified";

        private const string DefaultFullName = "Not specified";

        public string ShortName { get; }

        public string FullName { get; }

        public Name()
        {
            ShortName = DefaultShortName;
            FullName = DefaultFullName;
        }

        public Name(string shortName, string fullName)
        {
            if (shortName != null & fullName != null)
            {
                if (IsShortNameValid(shortName) && IsFullNameValid(fullName))
                {
                    ShortName = shortName.Trim();
                    FullName = fullName.Trim();
                }
                else if (!(IsShortNameValid(shortName) && IsFullNameValid(fullName)))
                    throw new BusinessRuleValidationException("Short and Full name are invalid");
                else if (!IsShortNameValid(shortName))
                    throw new BusinessRuleValidationException("Short name invalid");
                else
                    throw new BadHttpRequestException("Full name invalid");
            }
            else if (shortName == null && fullName == null)
            {
                ShortName = DefaultShortName;
                FullName = DefaultFullName;
            }
            else if (shortName == null)
            {
                ShortName = DefaultShortName;

                if (IsFullNameValid(fullName))
                    FullName = fullName;
                else
                    throw new BusinessRuleValidationException("Full name invalid");
            }
            else
                FullName = DefaultFullName;

            if (IsShortNameValid(shortName))
                ShortName = shortName;
            else
                throw new BusinessRuleValidationException("Short name invalid");
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