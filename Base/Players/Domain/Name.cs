using LEI_21s5_3dg_41.Domain.Shared;
using System;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class Name : IValueObject
    {
        public string ShortName { get; }
        public string FullName { get; }

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

    }
}
