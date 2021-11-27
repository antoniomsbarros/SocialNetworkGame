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
    }
}
