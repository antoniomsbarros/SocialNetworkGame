using SocialNetwork.core.shared;
using SocialNetwork.core.posts.dto.repository;

namespace SocialNetwork.core.posts.application
{
    public class PostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _repo;

        //private readonly IPlayerRepository _repoPlayer;

        public PostService(IUnitOfWork unitOfWork, IPostRepository repo /*IPlayerRepository repoPlayer*/)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            //this._repoPlayer = repoPlayer;
        }

    }
}