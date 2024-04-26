using Domain.Posts;
using Infrastructure.Data;
using MediatR;

namespace Application.Features.Posts.CommentOnAPost
{
    public class CommentOnAPostCommandHandler : IRequestHandler<CommentOnAPostCommand>
    {
        private readonly GiggleDbContext _context;

        public CommentOnAPostCommandHandler(GiggleDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CommentOnAPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(request.PostId) ?? throw new Exception();

            post.Comments.Add(new Comment { Content = request.Comment });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
