using Domain.Posts;
using Domain.Users;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var vote = await _context.Votes
            .Where(v => v.PostId == request.PostId && v.UserId == 1)
            .FirstOrDefaultAsync(cancellationToken);

        if (vote is null)
        {
            vote = new PostVote
            {
                PostId = request.PostId,
                UserId = 1,
                IsLiked = true
            };
        }
        else
        {
            vote.IsLiked = true;
        }
        await _context.SaveChangesAsync();
    }
}
