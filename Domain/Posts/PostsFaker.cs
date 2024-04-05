using Bogus;

namespace Domain.Posts;

public class PostsFaker: Faker<Post>
{
    public PostsFaker()
    {
        RuleFor(x => x.Title, x => x.Lorem.Sentence());
        RuleFor(x => x.ImagePath, x => x.Image.PicsumUrl());
    }
}
