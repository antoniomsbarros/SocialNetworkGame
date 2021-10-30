using System.Threading.Tasks;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;
//using LEI_21s5_3dg_41.Domain.Player;
using LEI_21s5_3dg_41.Domain.Tag;

namespace LEI_21s5_3dg_41.Domain.Post
{
    public class PostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _repo;
        private readonly ITagRepository _repoTag;
        //private readonly IPlayerRepository _repoPlayer;

        public PostService(IUnitOfWork unitOfWork, IPostRepository repo, ITagRepository repoTag /*IPlayerRepository repoPlayer*/)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
            this._repoTag = repoTag;
            //this._repoPlayer = repoPlayer;
        }

    }
}