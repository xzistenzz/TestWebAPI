namespace TestWebAPI.Domain.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string RelativePath { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
