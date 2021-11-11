using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.players.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
namespace SocialNetwork.core.model.missions.MissionRepository
{
    public class MissionRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public MissionRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
        
        public async Task Save(Mission mission)
        {
            _socialNetworkDbContext.Missions.Add(mission);
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        public List<Mission> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.Missions select VAR).ToList();
        }
        public Mission FindbyId(MissionId missionId)
        {
            Mission mission= (from VAR in _socialNetworkDbContext.Missions
                where VAR.Id == missionId
                select VAR).SingleOrDefault();
            if (mission==null)
            {
                throw new ArgumentNullException();
            }

            return mission;
        }
        
        public async Task RemoveIntroductionRequest(MissionId missionId)
        {
            _socialNetworkDbContext.Missions.Remove(this.FindbyId(missionId));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
    }
}