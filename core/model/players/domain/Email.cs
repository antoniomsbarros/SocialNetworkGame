using SocialNetwork.core.model.shared;
using System;
using System.Net.Mail;

namespace SocialNetwork.core.model.players.domain
{
    public class Email : IValueObject
    {

        public string EmailAddress { get; }

        protected Email()
        {
            // for ORM
        }

        public Email(string emailAddress)
        {
            if (IsValid(emailAddress))
                this.EmailAddress = emailAddress;
            else
                throw new BusinessRuleValidationException("Email address invalid");
        }

        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress email = new(emailaddress);
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

            Email otherEmail = (Email)obj;

            return otherEmail.EmailAddress.Equals(this.EmailAddress);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.EmailAddress);
        }
    }
}
