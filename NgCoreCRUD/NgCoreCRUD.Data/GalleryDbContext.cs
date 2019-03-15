using Microsoft.EntityFrameworkCore;
using NgCoreCRUD.Data.Configurations;
using NgCoreCRUD.Entities;

namespace NgCoreCRUD.Data
{
    public class GalleryDbContext : DbContext
    {
        public GalleryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<GalleryItem> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GalleryItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
