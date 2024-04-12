using Application.Common;
using Application.Services.Storage;
using Domain.Posts;
using Infrastructure.Data;
using MediatR;

namespace Application.Features.Posts.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<string>>
{
    private readonly GiggleDbContext _context;
    private readonly IStorageService _storageService;

    public CreatePostCommandHandler(GiggleDbContext context, IStorageService storageService)
    {
        _context = context;
        _storageService = storageService;
    }
    public async Task<Result<string>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        // TODO: get the user from the request
        var user = await _context.Users.FindAsync(1) ?? throw new Exception();
        var category = await _context.Categories.FindAsync(1) ?? throw new Exception();
        var pathToImage = await _storageService.UploadImageAsync(request.Image, cancellationToken);
        var post = new Post
        {
            Title = request.Title,
            ImagePath = pathToImage.Data,
            Author = user,
            Category = category
        };

        await _context.Posts.AddAsync(post, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(post.Id.ToString());
    }
}
