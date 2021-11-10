using SocialNetwork.infrastructure.application.authz;
using System;

namespace SocialNetwork.infrastructure.domain.authz
{
    public class SystemUser
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public SystemUser(string email, string password, IPasswordPolicy passwordPolicy)
        {
            if (!passwordPolicy.IsSatisfiedBy(password))
                throw new ArgumentException("The password doesn't satisfy the policy");

            this.Email = email;
            this.Password = password; // needs ecryption
        }


    }
}
