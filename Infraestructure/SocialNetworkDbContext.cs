using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.connectionRequests.domain;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.post;
using SocialNetwork.core.relationships.domain;

namespace SocialNetwork.infraestructure
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        // DB Entities 
        public DbSet<Player> Players { get; set; }
        public DbSet<RelationShip> RelationShips { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<DirectRequest> DirectRequests { get; set; }
        public DbSet<IntroductionRequest> IntroductionRequests { get; set; }


    }
}