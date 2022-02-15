using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _db;
        public PlatformRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Platform> CreatePlatform(Platform platform)
        {
            await _db.Platforms.AddAsync(platform);
            return platform;
        }

        public async Task<Platform> Get(int id)
        {
            var platform = await _db.Platforms.FindAsync(id);
            if (platform != null)
            {
                _db.Entry(platform).State = EntityState.Detached;
                return platform;
            }
            return platform;
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _db.Platforms.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
