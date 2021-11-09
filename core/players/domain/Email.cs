using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.shared;
using System;
using System.Net.Mail;

namespace SocialNetwork.core.players.domain
{
    [Owned]
    public class Email : IValueObject
    {

        public string EmailAddress { get; }

        protected Email()
        {
            // for ORM
        }

        public Email(String emailAddress)
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

    }
}
