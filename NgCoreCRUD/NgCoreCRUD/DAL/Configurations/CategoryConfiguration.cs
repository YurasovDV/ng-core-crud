using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgCoreCRUD.Model;

namespace NgCoreCRUD.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", Constants.Schema);

            builder.HasKey(g => g.CategoryId);

            builder.Property(g => g.Name).HasMaxLength(40);
            builder
                .HasMany(c => c.Pictures)
                .WithOne(g => g.Category)
                .HasForeignKey(g => g.CategoryId);
        }
    }
}
