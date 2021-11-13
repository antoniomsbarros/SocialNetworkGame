
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.infrastructure;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.core.model.systemUsers.repository
{
    public class SystemUserRepository : BaseRepository<SystemUser, Username>, ISystemUserRepository
    {
        public SystemUserRepository(SocialNetworkDbContext context) : base(context.Users)
        {
        }
    }
}