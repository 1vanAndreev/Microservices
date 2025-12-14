using DeliveryService.Data;
using DeliveryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly DeliveryDbContext _db;

    public SearchController(DeliveryDbContext db)
    {
        _db = db;
    }

    // GET /api/search/posts?query=hello&userId=1
    [HttpGet("posts")]
public async Task<IEnumerable<PostView>> SearchPosts(
    [FromQuery] string? query)
{
    var q = _db.Posts.AsQueryable();

    if (!string.IsNullOrWhiteSpace(query))
        q = q.Where(p => p.Title.Contains(query) || p.Content.Contains(query));

    return await q.ToListAsync();
}

}
