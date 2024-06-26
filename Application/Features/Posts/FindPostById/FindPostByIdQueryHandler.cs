﻿using Application.Common;
using Application.Features.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Posts.FindPostById
{
    public class FindPostByIdQueryHandler : IRequestHandler<FindPostByIdQuery, Result<PostDto.Detail>>
    {
        private readonly GiggleDbContext _context;

        public FindPostByIdQueryHandler(GiggleDbContext context)
        {
            _context = context;
        }

        public async Task<Result<PostDto.Detail>> Handle(FindPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.Where(post => post.Id == request.Id)
                .Include(post => post.Author)
                .Include(post => post.Category)
                .Include(post => post.Comments)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new Exception();

            var postDetail = new PostDto.Detail
            {
                Id = request.Id,
                Title = post.Title,
                ImagePath = post.ImagePath,
                Author = new UserDto.Index
                {
                    Id = post.Author.Id,
                    Username = post.Author.Username
                },
                Category = new CategoryDto.Index
                {
                    Id = post.Category.Id,
                    Name = post.Category.Name
                },
                Comments = post.Comments.Select(comment => new CommentDto.Index
                {
                    Id = comment.Id,
                    Content = comment.Content
                }).ToList()
            };

            return Result<PostDto.Detail>.Success(postDetail);
        }
    }

}
