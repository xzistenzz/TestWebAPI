using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;

namespace TestWebAPI.Persistance.Services.Repository.Abstraction
{
    public interface IFriendshipRepository : IRepository<Friendships>
    {
        Task<IEnumerable<Friendships>> GetAllRequestInFriendsAsync(int userId);
        Task UpdateStatusAsync(int friendShipId, FriendshipStatus status);
        Task<bool> CheckToFriend(int user1Id, int user2Id);
    }
}
