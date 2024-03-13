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

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Picture>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

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

        public Task UpdateAsync(Picture entity)
        {
            throw new NotImplementedException();
        }
    }
}
