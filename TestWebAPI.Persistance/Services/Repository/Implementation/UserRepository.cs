using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Exepctions;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services.Repository.Abstraction;

namespace TestWebAPI.Persistance.Services.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var user = await GetAsync(entityId);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.AsNoTracking().ToListAsync();

        public async Task<User> GetAsync(int entityId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == entityId);

            if (user == null)
                throw new NotFoundEntityException("Пользователь не найден!");

            return user;
        }

        public async Task<User> GetbyLogin(string login)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Login == login);

            if (user == null)
                throw new NotFoundEntityException($"Пользователь \"{login}\" не существует.");

            return user;
        }

        public async Task<User> GetNoTrackingAsync(int entityId)
        {
            var user = await _context.Users.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == entityId);

            if (user == null)
                throw new NotFoundEntityException("Пользователь не найден!");

            return user;
        }

        public async Task UpdateAsync(User entity)
        {
            var oldUserData = await GetAsync(entity.Id);

            oldUserData.Login = entity.Login;
            
            await _context.SaveChangesAsync();
        }
    }
}
