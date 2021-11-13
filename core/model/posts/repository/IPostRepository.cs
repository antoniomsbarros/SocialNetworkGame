using SocialNetwork.core.model.posts.domain.post;
using SocialNetwork.core.model.shared;

namespace SocialNetwork.core.model.posts.repository
{
    public interface IPostRepository : IRepository<Post, PostId>
    {
    }
}