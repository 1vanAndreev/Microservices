namespace UsersService.Models
{
    public class User
    {
        public int Id { get; set; }          // PK
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
