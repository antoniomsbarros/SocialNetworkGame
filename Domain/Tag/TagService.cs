using System.Threading.Tasks;
using System.Collections.Generic;
using LEI_21s5_3dg_41.Domain.Shared;

namespace LEI_21s5_3dg_41.Domain.Tag
{
    public class TagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagRepository _repo;

        public TagService(IUnitOfWork unitOfWork, ITagRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        } 

        
    }
}