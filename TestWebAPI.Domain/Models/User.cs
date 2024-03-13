using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = String.Empty;
        public string HashPassword { get; set; } = string.Empty;
        public List<User> Friends { get; set; } = [];
        public IReadOnlyCollection<Picture> Pictures => pictureList;
        private List<Picture> pictureList = new List<Picture>();
        public void AddPicture(Picture picture)
            => pictureList.Add(picture);

        public User(int id, string login, string password, List<User> friends, List<Picture> pictureList)
        {
            Id = id;
            Login = login;
            HashPassword = password;
            Friends = friends;
            this.pictureList = pictureList;
        }
    }
}
