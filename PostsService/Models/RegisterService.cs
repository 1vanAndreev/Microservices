namespace PostsService.Models
{
    public class Post
    {
        public int Id { get; set; }          // PK, Identity
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

