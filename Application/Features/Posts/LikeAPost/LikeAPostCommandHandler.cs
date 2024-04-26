using Domain.Posts;
using Domain.Users;
using Infrastructure.Data;
using MediatR;

namespace Application.Features.Posts.LikeAPost.LikeAPost;

public class LikeAPostCommandHandler : IRequestHandler<LikeAPostCommand>
{
    private readonly GiggleDbContext _context;

    public LikeAPostCommandHandler(GiggleDbContext context)
    {
        _context = context;
    }

    public async Task Handle(LikeAPostCommand request, CancellationToken cancellationToken)
    {
        Post post = await _context.Posts.FindAsync(request.PostId) ?? throw new Exception();
        User user = await _context.Users.FindAsync(1) ?? throw new Exception();
        post.LikedBy.Add(user);
        post.DislikedBy.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
