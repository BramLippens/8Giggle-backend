using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Posts.CreatePost
{
    public class CreatePostCommand : IRequest<Result<string>>
    {
        public string Title { get; set; }
        public IFormFile Image { get; set; }
    }
}
