using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCoreCRUD.Entities;

namespace NgCoreCRUD.Data.Configurations
{
    public class GalleryItemConfiguration : IEntityTypeConfiguration<GalleryItem>
    {
        public void Configure(EntityTypeBuilder<GalleryItem> builder)
        {
            builder.ToTable("Pictures", Constants.Schema);

            builder.HasKey(pict => pict.ID);

            builder.Property(pict => pict.Description).HasMaxLength(140);

            builder.Property(pict => pict.Image).HasColumnType("image");
        }
    }
}
