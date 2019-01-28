using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCoreCRUD.Model;

namespace NgCoreCRUD.DAL.Configurations
{
    public class GalleryItemConfiguration : IEntityTypeConfiguration<GalleryItem>
    {
        public void Configure(EntityTypeBuilder<GalleryItem> builder)
        {
            builder.ToTable("Pictures", Constants.Schema);

            builder.HasKey(pict => pict.ID);

            builder.Property(pict => pict.Description).HasMaxLength(140);
        }
    }
}
