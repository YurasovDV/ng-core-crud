using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            builder.HasKey(g => g.ID);

            builder.Property(g => g.Description).HasMaxLength(140);
        }
    }
}
