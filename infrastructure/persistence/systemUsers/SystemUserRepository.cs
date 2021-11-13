using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.core.model.systemUsers.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.systemUsers
{
    public class SystemUserRepository : BaseRepository<SystemUser, Username>, ISystemUserRepository
    {
        public SystemUserRepository(SocialNetworkDbContext context) : base(context.Users)
        {
        }
    }
}