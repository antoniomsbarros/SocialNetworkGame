using SocialNetwork.core.posts.domain.post;
using SocialNetwork.core.shared;

namespace SocialNetwork.core.posts.dto.repository
{
    public interface IPostRepository : IRepository<Post, long>
    {
    }
}