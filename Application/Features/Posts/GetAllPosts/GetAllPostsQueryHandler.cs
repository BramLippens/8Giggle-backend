using Application.Common;
using Application.Features.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Posts.GetAllPosts;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Result<PaginatedList<PostDto.Index>>>
{
    private readonly GiggleDbContext _context;

    public GetAllPostsQueryHandler(GiggleDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PaginatedList<PostDto.Index>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Posts
            .OrderBy(p => p.CreatedAt)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new PostDto.Index()
            {
                Id = p.Id,
                Title = p.Title,
                ImagePath = p.ImagePath,
                Likes = p.Equals(null) ? 0 : p.Votes.Count(v => v.IsLiked),
                Dislikes = p.Equals(null) ? 0 : p.Votes.Count(v => !v.IsLiked),
                comments = p.Equals(null) ? 0 : p.Comments.Count
            })
            .ToListAsync(cancellationToken);

        var count = await _context.Posts.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

        return Result<PaginatedList<PostDto.Index>>.Success(new PaginatedList<PostDto.Index>(result, request.PageIndex, totalPages));
    }
}
