using Application.Features.Shared;
using MediatR;

namespace Application.Features.Posts.FindPostById
{
    public class FindPostByIdQuery : IRequest<PostDto.Detail>
    {
        public int Id { get; set; }
    }
}
