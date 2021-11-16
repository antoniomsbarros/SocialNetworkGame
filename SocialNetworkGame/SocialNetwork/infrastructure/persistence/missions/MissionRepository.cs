using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.missions.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.missions
{
    public class MissionRepository : BaseRepository<Mission, MissionId>, IMissionRepository
    {
        public MissionRepository(SocialNetworkDbContext socialNetworkDbContext) : base(socialNetworkDbContext.Missions)
        {
        }
    }
}