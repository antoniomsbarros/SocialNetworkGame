using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
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

        public async Task<List<TagDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.ConvertAll(player => player.ToDto());
        }

        public async Task<TagDto> GetByIdAsync(TagId id)
        {
            var tag = await _repo.GetByIdAsync(id);

            if (tag == null)
                return null;

            return tag.ToDto();
        }

        public async Task<TagDto> GetByNameAsync(TagName tagName)
        {
            var tag = await _repo.GetByNameAsync(tagName);

            if (tag == null)
                return null;

            return tag.ToDto();
        }
    }
}