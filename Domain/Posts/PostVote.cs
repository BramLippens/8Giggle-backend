using Domain.Common;
using Domain.Users;

namespace Domain.Posts
{
    public class PostVote : Entity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsLiked { get; set; }

        public PostVote() { }
    }

}
