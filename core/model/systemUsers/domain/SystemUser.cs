using System;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.systemUsers.domain
{
    public class SystemUser : Entity<Username>
    {
        public Password Password { get; set; }

        protected SystemUser()
        {
            // for ORM
        }

        public SystemUser(Username username, Password password)
        {
            this.Id = username;
            this.Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            if (obj.GetType() != typeof(SystemUser))
                return false;

            SystemUser otherUser = (SystemUser) obj;

            return otherUser.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}