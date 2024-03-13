using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Domain.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string RelativePath { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public Picture(int id, string relativePath, int userId, User user)
        {
            Id = id;
            RelativePath = relativePath;
            UserId = userId;
            User = user;
        }
    }
}
