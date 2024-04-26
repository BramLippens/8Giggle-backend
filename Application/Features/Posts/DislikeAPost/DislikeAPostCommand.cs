using MediatR;

namespace Application.Features.Posts.DislikeAPost;

public class DislikeAPostCommand : IRequest
{
    public int PostId { get; set; }
}
