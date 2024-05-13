
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

        //DbUp.Program.Main(new string[] { });
        _context.Database.EnsureCreated();

        SeedPosts();
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

        foreach(var _ in Enumerable.Range(0, 20))
        {
            var post = new PostsFaker()
                .RuleFor(p => p.Id, () => 0)
                .RuleFor(p => p.Author, () => faker.PickRandom(users))
                .RuleFor(p => p.Category, () => faker.PickRandom(categories))
                .Generate();

            _context.Posts.Add(post);

            var selectedUsers = faker.PickRandom(users, 5);

            foreach(var user in selectedUsers)
            {
                var vote = new PostVote
                {
                    User = user,
                    Post = post,
                    IsLiked = faker.Random.Bool()
                };

                _context.Votes.Add(vote);
            }

            var comments = new Faker<Comment>()
                .RuleFor(c => c.Id, () => 0)
                .RuleFor(c => c.Post, () => post)
                .RuleFor(c => c.Content, () => faker.Lorem.Sentence())
                .Generate(5);

            post.Comments = comments;
        }

        _context.SaveChanges();
    }
}
