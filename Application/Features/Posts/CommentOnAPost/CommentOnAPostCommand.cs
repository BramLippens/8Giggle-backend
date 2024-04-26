using MediatR;

namespace Application.Features.Posts.CommentOnAPost
{
    public class CommentOnAPostCommand : IRequest
    {
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}
