using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            //builder.HasMany(c => c.Posts).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            builder.Property(u => u.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(u => u.UpdatedAt).HasColumnName("updated_at").IsRequired();
            builder.Property(u => u.IsEnabled).HasColumnName("is_enabled").IsRequired();
        }
    }
}
