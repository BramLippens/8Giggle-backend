using Domain.Common;

namespace Domain.Posts;

public class Comment : Entity
{
    public string Content { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}
