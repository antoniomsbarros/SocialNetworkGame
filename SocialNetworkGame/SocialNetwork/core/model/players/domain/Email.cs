using SocialNetwork.core.model.shared;
using System;
using System.Net.Mail;

namespace SocialNetwork.core.model.players.domain
{
    public class Email : IValueObject
    {
        public string Address { get; }

        protected Email()
        {
            // for ORM
        }

        public Email(string address)
        {
            if (IsValid(address))
                Address = address;
            else
                throw new BusinessRuleValidationException("Invalid Email Address");
        }

        public static bool IsValid(string emailAddress)
        {
            try
            {
                MailAddress email = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static Email ValueOf(string emailAddress)
        {
            return new(emailAddress);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Email))
                return false;

            Email otherEmail = (Email) obj;

            return otherEmail.Address.Equals(Address);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address);
        }
    }
}