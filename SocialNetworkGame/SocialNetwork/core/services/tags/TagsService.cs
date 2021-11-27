using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.repository;

namespace SocialNetwork.core.services.tags
{
    public class TagsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagRepository _repo;

        public TagsService(IUnitOfWork unitOfWork, ITagRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }
    }
}
