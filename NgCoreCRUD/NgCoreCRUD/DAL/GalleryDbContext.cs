using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NgCoreCRUD.DAL.Configurations;
using NgCoreCRUD.Model;

namespace NgCoreCRUD.DAL
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
