namespace Application.Features.Shared;

public abstract class CommentDto
{
    public class Index
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserDto.Index Author { get; set; }
    }
}
