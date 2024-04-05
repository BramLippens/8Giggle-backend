using Bogus;

namespace Domain.Posts;

public class CategoryFaker: Faker<Category>
{
    public CategoryFaker()
    {
        RuleFor(x => x.Id, x => x.IndexFaker + 1);
        RuleFor(x => x.Name, x => x.Commerce.Categories(1).First());
    }
}
