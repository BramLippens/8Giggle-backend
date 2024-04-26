using Application.Features.Posts.CommentOnAPost;
using Application.Features.Posts.CreatePost;
using Application.Features.Posts.DislikeAPost;
using Application.Features.Posts.FindPostById;
using Application.Features.Posts.GetAllPosts;
using Application.Features.Posts.LikeAPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController: ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] GetAllPostsQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var result = await _mediator.Send(new FindPostByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostCommand request)
    {
        var result = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetPostById), new { id = result.Data }, result);
    }
    [HttpPost("{id}/comment")]
    public async Task<IActionResult> CommentOnPost(int id, [FromBody] string comment)
    {
        await _mediator.Send(new CommentOnAPostCommand() { Comment = comment, PostId = id});
        return Ok();
    }
    [HttpPost("{id}/like")]
    public async Task<IActionResult> LikePost(int id)
    {
        await _mediator.Send(new LikeAPostCommand() { PostId = id });
        return Ok();
    }
    [HttpPost("{id}/unlike")]
    public async Task<IActionResult> DislikePost(int id)
    {
        await _mediator.Send(new DislikeAPostCommand() { PostId = id });
        return Ok();
    }
}
