using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.tags
{
    public class TagRepository : BaseRepository<Tag, TagId>, ITagRepository
    {
        private readonly SocialNetworkDbContext context;

        public TagRepository(SocialNetworkDbContext context) : base(context.Tag)
        {
            this.context = context;
        }

        public async Task<Tag> GetByNameAsync(TagName name)
        {
            return await _objs
                .Where(tag => tag.TagName.Value.Equals(name.Value))
                .FirstOrDefaultAsync();
        }
    }
}