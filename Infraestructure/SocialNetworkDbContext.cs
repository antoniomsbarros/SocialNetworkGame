using Microsoft.EntityFrameworkCore;
using LEI_21s5_3dg_41.Domain.Categories;
using LEI_21s5_3dg_41.Domain.Products;
using LEI_21s5_3dg_41.Domain.Families;
using LEI_21s5_3dg_41.Infrastructure.Categories;
using LEI_21s5_3dg_41.Infrastructure.Products;

namespace LEI_21s5_3dg_41.Infrastructure
{
    public class SocialNetworkDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Family> Families { get; set; }

        public SocialNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyEntityTypeConfiguration());
        }
    }
}