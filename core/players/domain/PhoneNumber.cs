using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System.Text.RegularExpressions;

namespace SocialNetwork.core.players.domain
{
    [Owned]
    public class PhoneNumber : IValueObject
    {
        public string Number { get; }

        private static readonly string PHONE_NUMBER_REGEX_RULE = "[0-9]*";

        protected PhoneNumber()
        {
            // for ORM
        }
        public PhoneNumber(string number)
        {
            if (IsValid(number))
                this.Number = number;
            else
                throw new BusinessRuleValidationException("Phone number invalid");
        }

        public static bool IsValid(string number)
        {
            Regex regex = new(PHONE_NUMBER_REGEX_RULE);
            return regex.IsMatch(number);
        }

    }
}
