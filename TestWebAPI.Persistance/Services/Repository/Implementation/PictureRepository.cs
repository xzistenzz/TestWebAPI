using Microsoft.EntityFrameworkCore;
using TestWebAPI.Domain.Exepctions;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services.Repository.Abstraction;

namespace TestWebAPI.Persistance.Services.Repository.Implementation
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationContext _context;

        public PictureRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Picture entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Pictures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var picture = await GetAsync(entityId);
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Picture>> GetAllAsync()
            => await _context.Pictures.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Picture>> GetAllAsync(int userId)
            => await _context.Pictures.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();

        public async Task<Picture> GetAsync(int entityId)
        {
            var picture = await _context.Pictures.SingleOrDefaultAsync(x => x.Id == entityId);

            if (picture == null)
                throw new NotFoundEntityException("Изображение не найдено!");

            return picture;
        }

        public async Task<Picture> GetNoTrackingAsync(int entityId)
        {
            var picture = await _context.Pictures.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == entityId);

            if (picture == null)
                throw new NotFoundEntityException("Изображение не найдено!");

            return picture;
        }

        public async Task UpdateAsync(Picture entity)
        {
            var pictureOldData = await GetAsync(entity.Id);

            pictureOldData.RelativePath = entity.RelativePath;
            await _context.SaveChangesAsync();
        }
    }
}
