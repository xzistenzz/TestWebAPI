using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;

namespace TestWebAPI.Application.Services.Abstraction
{
    public interface IPictureService
    {
        Task AddPicture(Picture picture, int userId);

        Task<IEnumerable<Picture>> GetPictureFriendAsync(int user1Id, int user2id);
    }
}
