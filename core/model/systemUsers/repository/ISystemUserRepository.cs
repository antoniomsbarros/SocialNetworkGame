using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.domain;

namespace SocialNetwork.core.model.systemUsers.repository
{
    public interface ISystemUserRepository : IRepository<SystemUser, Username>
    {
    }
}