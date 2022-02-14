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
        public void CreatePlatform(Platform platform)
        {
            _db.Platforms.Add(platform);
        }

        public void Delete(int id)
        {
            var platForm = Get(id);
            _db.Platforms.Remove(platForm);
        }

        public Platform Get(int id)
        {
            return _db.Platforms.FirstOrDefault(p => p.Id == id);   
        }

        public IEnumerable<Platform> GetAll()
        {
            return _db.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_db.SaveChanges() > 0);
        }
    }
}
