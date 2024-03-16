namespace TestWebAPI.Domain.Models
{
    public class Friendships
    {
        public int Id { get; set; }
        public int UserFromId { get; set; }
        public User UserFrom { get; set; } = null!;
        public int UserToId { get; set;}
        public User UserTo { get; set; } = null!;
        public FriendshipStatus Status { get; set; }
        public DateTime DateTimeCreate { get; set; }              

        public Friendships()
        {
            DateTimeCreate = DateTime.Now;                                                               
        }
    }
}
