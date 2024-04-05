using Domain.Common;
using Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Posts;

public class Post: Entity
{
    public string Title { get; set; }
    public string ImagePath { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [Column("user_id")]
    public int AuthorId { get; set; }
    public User Author { get; set; }

    public Post() { }

    public Post(string title, string imagePath, Category category, User author)
    {
        Title = title;
        ImagePath = imagePath;
        Category = category;
        Author = author;
    }
}
