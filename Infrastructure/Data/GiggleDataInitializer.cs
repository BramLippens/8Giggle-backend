
using Bogus;
using Domain.Posts;
using Domain.Users;

namespace Infrastructure.Data;

public class GiggleDataInitializer
{
    private readonly GiggleDbContext _context;

    public GiggleDataInitializer(GiggleDbContext context)
    {
        _context = context;
    }

    public void SeedData()
    {
        _context.Database.EnsureDeleted();
        if (_context.Database.EnsureCreated())
        {
            SeedPosts();
        }
    }

    private void SeedPosts()
    {
        var users = new UserFaker().RuleFor(u => u.Id, () => 0).Generate(10);
        _context.Users.AddRange(users);
        _context.SaveChanges();

        var categories = new CategoryFaker().RuleFor(c => c.Id, () => 0).Generate(10);
        _context.Categories.AddRange(categories);
        _context.SaveChanges();


        var faker = new Faker();

        var posts = new PostsFaker()
            .RuleFor(f => f.Category, faker.Random.ListItem(categories)) // Pick a random category for each post
            .RuleFor(f => f.Author, faker.Random.ListItem(users)) // Pick a random user's Id as the author for each post
            .RuleFor(p => p.Id, () => 0)
            .Generate(100);

        _context.Posts.AddRange(posts);
        _context.SaveChanges();
    }
}
