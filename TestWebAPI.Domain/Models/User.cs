namespace TestWebAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public List<Friendships> Friends { get; set; } = [];
        private List<Picture> pictureList = new List<Picture>();
        public IReadOnlyCollection<Picture> Pictures => pictureList;
        public void AddPicture(Picture picture)
            => pictureList.Add(picture);
    }
}
