using Domain.Posts;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var vote = await _context.Votes
            .Where(v => v.PostId == request.PostId && v.UserId == 1)
            .FirstOrDefaultAsync(cancellationToken);
        if(vote is null)
        {
            vote = new PostVote
            {
                PostId = request.PostId,
                UserId = 1,
                IsLiked = false
            };
            await _context.Votes.AddAsync(vote, cancellationToken);
        }
        else
        {
            vote.IsLiked = false;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
