using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Firstname).HasColumnName("firstname").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Lastname).HasColumnName("lastname").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Username).HasColumnName("username").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).HasColumnName("email").IsRequired().HasMaxLength(50);
        builder.Property(u => u.Role).HasColumnName("role").IsRequired().HasMaxLength(50);
        builder.Property(u => u.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at").IsRequired();
        builder.Property(u => u.IsEnabled).HasColumnName("is_enabled").IsRequired();


        builder.OwnsOne(u => u.Address, address =>
        {
            address.Property(a => a.Street).HasColumnName("street").HasMaxLength(50);
            address.Property(a => a.City).HasColumnName("city").HasMaxLength(50);
            address.Property(a => a.Postalcode).HasColumnName("postal_code").HasMaxLength(50);
            address.Property(a => a.Country).HasColumnName("country").HasMaxLength(50);
        }).Navigation(c=>c.Address).IsRequired();

        builder.HasMany(u => u.Posts).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);

        builder.HasMany(u => u.Likes).WithMany(p => p.LikedBy).UsingEntity(j => j.ToTable("user_likes"));
        builder.HasMany(u => u.Dislikes).WithMany(p => p.DislikedBy).UsingEntity(j => j.ToTable("user_dislikes"));
    }
}
