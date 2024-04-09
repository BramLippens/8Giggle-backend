using Bogus;

namespace Domain.Posts;

public class PostsFaker: Faker<Post>
{
    public PostsFaker()
    {
        RuleFor(x => x.Title, x => x.Lorem.Sentence());
        RuleFor(x => x.ImagePath, x => {
            string[] dimensions = ["200", "300", "400", "500", "600", "700", "800", "900", "1000"];
            return $"https://picsum.photos/{dimensions[x.Random.Number(0, 8)]}/{dimensions[x.Random.Number(0, 8)]}/?image={x.Random.Number(0,999)}";
        });
    }
}
