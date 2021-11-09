using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.connectionRequests.domain;
using SocialNetwork.core.missions.domain;
using SocialNetwork.core.players.domain;
using SocialNetwork.core.posts.domain.post;
using SocialNetwork.core.relationships.domain;
using SocialNetwork.infrastructure.connectionRequests;
using SocialNetwork.infrastructure.missions;
using SocialNetwork.infrastructure.players;
using SocialNetwork.infrastructure.posts.comment;
using SocialNetwork.infrastructure.posts.post;
using SocialNetwork.infrastructure.posts.reaction;
using SocialNetwork.infrastructure.relationships;

namespace SocialNetwork.infrastructure
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConnectionRequestEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new DirectRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IntroductionRequestEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MissionEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new ProfileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CommentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RelationShipEntityTypeConfiguration());
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