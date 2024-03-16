using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Application.Services.Abstraction;
using TestWebAPI.Domain.Exepctions;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services.Repository.Abstraction;

namespace TestWebAPI.Application.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepo;
        private readonly IUserRepository _userRepo;
        private readonly IFriendshipRepository _friendshipRepo;

        public PictureService(IPictureRepository pictureRepo, IUserRepository userRepo, IFriendshipRepository friendshipRepo)
        {
            _pictureRepo = pictureRepo;
            _userRepo = userRepo;
            _friendshipRepo = friendshipRepo;
        }

        public async Task AddPicture(Picture picture, int userId)
        {
            if (picture == null) 
                throw new ArgumentNullException(nameof(picture));

            var user  = await _userRepo.GetAsync(userId);
            picture.User = user;

            await _pictureRepo.CreateAsync(picture);
        }

        public async Task<IEnumerable<Picture>> GetPictureFriendAsync(int user1Id, int user2Id)
        {
            if (await _friendshipRepo.CheckToFriend(user1Id, user2Id))
                return await _pictureRepo.GetAllAsync(user2Id);

            throw new NotFriendsException("Нет в друзьях.");
        }
    }
}
