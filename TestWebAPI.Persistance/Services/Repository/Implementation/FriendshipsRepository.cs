using Microsoft.EntityFrameworkCore;
using TestWebAPI.Domain.Exepctions;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services.Repository.Abstraction;

namespace TestWebAPI.Persistance.Services.Repository.Implementation
{
    public class FriendshipsRepository : IFriendshipRepository
    {
        private readonly ApplicationContext _context;

        public FriendshipsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckToFriend(int user1Id, int user2Id)
        {
            var quary = _context.Friendships
                .Where(x => (x.UserFromId == user1Id && x.UserToId == user2Id) || x.UserFromId == user2Id && x.UserToId == user1Id);

            quary = quary.Where(x => x.Status == FriendshipStatus.Accepted);

            return await quary.AnyAsync();
        }

        public async Task CreateAsync(Friendships entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Friendships.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var friendShip = await GetAsync(entityId);
            _context.Friendships.Remove(friendShip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Friendships>> GetAllAsync()
            => await _context.Friendships.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Friendships>> GetAllRequestInFriendsAsync(int userId)
        {
            var quary = _context.Friendships.AsNoTracking();
            quary = quary.Where(x => x.UserToId == userId);
            quary = quary.Where(x => x.Status == FriendshipStatus.WaitRespons);

            return await quary.ToListAsync();
        }

        public async Task<Friendships> GetAsync(int entityId)
        {
            var friendShip = await _context.Friendships.FirstOrDefaultAsync(x => x.Id == entityId);
            if (friendShip == null)
                throw new NotFoundEntityException("Запрос в друзья не найден.");

            return friendShip;
        }

        public async Task<Friendships> GetNoTrackingAsync(int entityId)
        {
            var friendShip = await _context.Friendships.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (friendShip == null)
                throw new NotFoundEntityException("Запрос в друзья не найден.");

            return friendShip;
        }

        public async Task UpdateAsync(Friendships entity)
        {
            var oldFriendshipsData = await GetAsync(entity.Id);
            oldFriendshipsData.Status = entity.Status;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int friendShipId, FriendshipStatus status)
        {
            var friendShip = await GetAsync(friendShipId);
            friendShip.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
