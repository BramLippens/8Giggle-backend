using Domain.Common;

namespace Domain.Posts;

public class Category: Entity
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();

    public Category() { }

    public Category(string name)
    {
        Name = name;
    }
}
