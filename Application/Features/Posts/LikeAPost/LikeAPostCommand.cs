using MediatR;

namespace Application.Features.Posts.LikeAPost;

public class LikeAPostCommand : IRequest
{
    public int PostId { get; set; }
}
