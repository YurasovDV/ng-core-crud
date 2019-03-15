using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCoreCRUD.Entities;

namespace NgCoreCRUD.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", Constants.Schema);

            builder.HasKey(cat => cat.CategoryId);

            builder.Property(cat => cat.Name).HasMaxLength(40);
            builder
                .HasMany(cat => cat.Pictures)
                .WithOne(pict => pict.Category)
                .HasForeignKey(pict => pict.CategoryId);
        }
    }
}
