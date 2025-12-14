using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostsService.Data;
using PostsService.Models;

namespace PostsService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostsDbContext _context;
    private readonly ILogger<PostsController> _logger;

    public PostsController(PostsDbContext context, ILogger<PostsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        post.Id = 0;
        post.CreatedAt = DateTime.UtcNow;

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Post {PostId} created", post.Id);
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return NotFound();
        return post;
    }
}
