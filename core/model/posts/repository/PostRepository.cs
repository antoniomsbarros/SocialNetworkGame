using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.players.domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using System.Linq;
using SocialNetwork.core.model.posts.domain.post;
using SocialNetwork.core.model.relationships.domain;
namespace SocialNetwork.core.model.posts.dto.repository
{
    public class PostRepository
    {
        private SocialNetworkDbContext _socialNetworkDbContext;

        public PostRepository(SocialNetworkDbContext socialNetworkDbContext)
        {
            _socialNetworkDbContext = socialNetworkDbContext;
        }
        
        public async Task Save(Post post)
        {
            _socialNetworkDbContext.Posts.Add(post);
            await _socialNetworkDbContext.SaveChangesAsync();
        }
        public List<Post> FindAll()
        {
            return (from VAR in _socialNetworkDbContext.Posts select VAR).ToList();
        }
        public Post FindbyId(PostId postId)
        {
            Post post= (from VAR in _socialNetworkDbContext.Posts
                where VAR.Id == postId
                select VAR).SingleOrDefault();
            if (post==null)
            {
                throw new ArgumentNullException();
            }

            return post;
        }
        
        public async Task RemoveIntroductionRequest(PostId postId)
        {
            _socialNetworkDbContext.Posts.Remove(this.FindbyId(postId));
            await _socialNetworkDbContext.SaveChangesAsync();
        }
    }
}