using Application.Common;
using Application.Features.Shared;
using MediatR;

namespace Application.Features.Posts.GetAllPosts;

public class GetAllPostsQuery : IRequest<Result<PaginatedList<PostDto.Index>>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
