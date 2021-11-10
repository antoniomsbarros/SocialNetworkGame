using System;
using SocialNetwork.infrastructure.authz.domain.application;

namespace SocialNetwork.infrastructure.authz.domain.model
{
    public class SystemUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        protected SystemUser()
        {
            // for ORM
        }

        public SystemUser(string email, string password, IPasswordPolicy passwordPolicy)
        {
            if (!passwordPolicy.IsSatisfiedBy(password))
                throw new ArgumentException("The password doesn't satisfy the policy");

            this.Email = email;
            this.Password = password; // needs encryption
        }
    }
}