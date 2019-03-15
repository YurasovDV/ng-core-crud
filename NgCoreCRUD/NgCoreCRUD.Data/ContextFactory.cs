using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NgCoreCRUD.Data
{
    internal class ContextFactory : IDesignTimeDbContextFactory<GalleryDbContext>
    {
        public GalleryDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GalleryDbContext>();
            builder.UseSqlServer("Server=ASUS;Database=GalleryDB; User ID = sa; Password=12345; Trusted_Connection=True;", options => options.CommandTimeout(120));
            return new GalleryDbContext(builder.Options);
        }
    }
}
