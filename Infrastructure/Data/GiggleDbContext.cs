using Domain.Posts;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GiggleDbContext : DbContext
{
    public GiggleDbContext(DbContextOptions<GiggleDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GiggleDbContext).Assembly);
    }
}
