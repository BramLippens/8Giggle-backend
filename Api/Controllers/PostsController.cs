using Application.Features.Posts.FindPostById;
using Application.Features.Posts.GetAllPosts;
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
}
