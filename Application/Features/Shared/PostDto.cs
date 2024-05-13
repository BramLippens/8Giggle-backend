namespace Application.Features.Shared;

public abstract class PostDto
{
    public class Index
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int comments { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public UserDto.Index Author { get; set; }
        public CategoryDto.Index Category { get; set; }
        public List<CommentDto.Index> Comments { get; set; }
    }
}
