using LEI_21s5_3dg_41.Domain.Shared;
using System;
using System.Net.Mail;

namespace LEI_21s5_3dg_41.Domain.Players
{
    public class Email : IValueObject
    {

        public string EmailAddress { get; }

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
