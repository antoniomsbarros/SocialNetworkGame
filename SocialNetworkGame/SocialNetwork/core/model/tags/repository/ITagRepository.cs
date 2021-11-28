using System.Threading.Tasks;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.tags.repository
{
    public interface ITagRepository : IRepository<domain.Tag, TagId>
    {
        Task<Tag> GetByNameAsync(TagName name);
    }
}