using SocialNetwork.core.model.shared;
using System;
using System.Text.RegularExpressions;

namespace SocialNetwork.core.model.players.domain
{
    public class PhoneNumber : IValueObject
    {
        public string Number { get; }

        private const string PhoneNumberRegex = "[0-9]*";

        protected PhoneNumber()
        {
            // for ORM
        }

        public PhoneNumber(string number)
        {
            if (IsValid(number))
                Number = number;
            else
                throw new BusinessRuleValidationException("Phone number invalid");
        }

        public static bool IsValid(string number)
        {
            return new Regex(PhoneNumberRegex).IsMatch(number);
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

            PhoneNumber otherPhoneNumber = (PhoneNumber) obj;
            return otherPhoneNumber.Number.Equals(Number);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number);
        }
    }
}