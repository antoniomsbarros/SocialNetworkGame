using SocialNetwork.core.model.posts.domain.post;
using SocialNetwork.core.model.posts.repository;
using SocialNetwork.infrastructure.persistence.Shared;

namespace SocialNetwork.infrastructure.persistence.posts
{
    public class PostRepository : BaseRepository<Post, PostId>, IPostRepository
    {
        public PostRepository(SocialNetworkDbContext socialNetworkDbContext) : base(socialNetworkDbContext.Posts)
        {
        }
    }
}