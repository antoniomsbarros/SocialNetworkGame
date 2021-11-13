using Microsoft.EntityFrameworkCore;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.missions.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.domain.post;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.infrastructure.persistence;
using SocialNetwork.infrastructure.persistence.authz;
using SocialNetwork.infrastructure.persistence.connectionRequests;
using SocialNetwork.infrastructure.persistence.missions;
using SocialNetwork.infrastructure.persistence.players;
using SocialNetwork.infrastructure.persistence.posts.comment;
using SocialNetwork.infrastructure.persistence.posts.post;
using SocialNetwork.infrastructure.persistence.posts.reaction;
using SocialNetwork.infrastructure.persistence.relationships;

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

            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CommentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RelationShipEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new SystemUserEntityTypeConfiguration());
        }

        // DB Entities 

        public DbSet<SystemUser> Users { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<Relationship> Relationships { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Mission> Missions { get; set; }

        public DbSet<DirectRequest> DirectRequests { get; set; }

        public DbSet<ConnectionRequest> ConnectionRequests { get; set; }

        public DbSet<IntroductionRequest> IntroductionRequests { get; set; }

        public RepositoryFactory Repositories()
        {
            return new RepositoryFactory(this);
        }
    }
}