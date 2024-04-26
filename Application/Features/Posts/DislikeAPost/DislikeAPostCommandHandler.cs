using Infrastructure.Data;
using MediatR;

namespace Application.Features.Posts.DislikeAPost;

public class DislikeAPostCommandHandler : IRequestHandler<DislikeAPostCommand>
{
    private readonly GiggleDbContext _context;

    public DislikeAPostCommandHandler(GiggleDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DislikeAPostCommand request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.FindAsync(request.PostId) ?? throw new Exception();
        var user = await _context.Users.FindAsync(1) ?? throw new Exception();
        post.LikedBy.Remove(user);
        post.DislikedBy.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
