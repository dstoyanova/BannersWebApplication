using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannersWebApplication
{
    public class BannerRepository : IBannerRepository
    {
        private readonly IBannerContext _context;

        public BannerRepository(IBannerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banner>> GetAllBanners()
        {
            return await _context
                .Banners
                .Find(_ => true)
                .ToListAsync();
        }

        public Task<Banner> GetBanner(int id)
        {
            FilterDefinition<Banner> filter = Builders<Banner>.Filter.Eq(m => m.BannerId, id);

            return _context
                .Banners
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task Create(Banner banner)
        {
            await _context.Banners.InsertOneAsync(banner);
        }

        public async Task<bool> Update(Banner banner)
        {
            ReplaceOneResult updateResult =
                await _context
                    .Banners
                    .ReplaceOneAsync(
                        filter: g => g.Id == banner.Id,
                        replacement: banner);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(int id)
        {
            FilterDefinition<Banner> filter = Builders<Banner>.Filter.Eq(m => m.BannerId, id);

            DeleteResult deleteResult =
                await _context
                    .Banners
                    .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
