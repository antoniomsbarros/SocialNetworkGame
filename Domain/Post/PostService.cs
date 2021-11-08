using System.Threading.Tasks;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;
//using LEI_21s5_3dg_41.Domain.Player;


namespace LEI_21s5_3dg_41.Domain.Post
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