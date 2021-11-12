using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.infrastructure.persistence.Shared;
namespace SocialNetwork.core.model.connectionRequests.repository
{
    public interface IIntroductionRequestRepository: IRepository<IntroductionRequest, ConnectionRequestId>
    {
        List<IntroductionRequest> GetAllPendingIntroductionAsync(PlayerId playerIntroductionId);
    }
}