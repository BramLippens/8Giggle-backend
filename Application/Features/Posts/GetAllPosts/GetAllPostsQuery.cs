using Application.Common;
using MediatR;

namespace Application.Features.Posts.GetAllPosts;

public class GetAllPostsQuery : IRequest<ApiResponse>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
