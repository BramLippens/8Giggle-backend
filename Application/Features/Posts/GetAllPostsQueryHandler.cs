using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Posts
{
    public class GetAllPostsResponse
    {
        public List<PostDto> Posts { get; set; } = new List<PostDto>();
        public class PostDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ImagePath { get; set; }
        }
    }
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsResponse>
    {
        private readonly GiggleDbContext _context;

        public GetAllPostsQueryHandler(GiggleDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllPostsResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Posts
                .Select(p => new GetAllPostsResponse.PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImagePath = p.ImagePath
                })
                .ToListAsync(cancellationToken);

            return new GetAllPostsResponse
            {
                Posts = result
            };
        }
    }
}
