using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.connectionRequests.domain;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.post;
using SocialNetwork.core.relationships.domain;

namespace SocialNetwork.infrastructure
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<RelationShip>().ToTable("PlayersRelationShip");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Mission>().ToTable("Mission");
            modelBuilder.Entity<DirectRequest>().ToTable("DirectRequest");
            modelBuilder.Entity<IntroductionRequest>().ToTable("IntroductionRequest");
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