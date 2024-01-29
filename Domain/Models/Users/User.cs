namespace Domain.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
