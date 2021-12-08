using System.Text;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.application;

namespace SocialNetwork.core.model.systemUsers.domain
{
    public class Password : IValueObject
    {
        public string Value { get; }

        protected Password()
        {
            //for ORM
        }

        public Password(string pass)
        {
            Value = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(pass));
        }

        public Password(string pass, IPasswordPolicy passwordPolicy)
        {
            if (IsValid(pass, passwordPolicy))
                Value = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(pass));
            else
                throw new BusinessRuleValidationException("The password doesn't meet the requirements");
        }

        public static bool IsValid(string pass, IPasswordPolicy passwordPolicy)
        {
            return passwordPolicy.IsValidPassword(pass);
        }

        public static Password ValueOf(string password, IPasswordPolicy passwordPolicy)
        {
            return new Password(password, passwordPolicy);
        }

        public static Password ValueOf(string password)
        {
            return new Password(password);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(Password))
                return false;

            Password otherPass = (Password) obj;

            return otherPass.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
    }
}