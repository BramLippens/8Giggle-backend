using Application.Common;
using Application.Features.Shared;
using MediatR;

namespace Application.Features.Posts.FindPostById
{
    public class FindPostByIdQuery : IRequest<Result<PostDto.Detail>>
    {
        public int Id { get; set; }
    }
}
