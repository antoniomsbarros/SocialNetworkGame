using SocialNetwork.core.shared;
using System;
using System.Text.RegularExpressions;

namespace SocialNetwork.core.players.domain
{
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

        public static PhoneNumber ValueOf(string number)
        {
            return new PhoneNumber(number);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(PhoneNumber))
                return false;

            PhoneNumber otherPhoneNumber = (PhoneNumber)obj;

            return otherPhoneNumber.Number.Equals(this.Number);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Number);
        }
    }
}
