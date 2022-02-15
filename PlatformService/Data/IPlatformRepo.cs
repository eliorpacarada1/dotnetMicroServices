using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        Task<bool> SaveChanges();

        Task<IEnumerable<Platform>> GetAll();

        Task<Platform> Get(int id);

        Task<Platform> CreatePlatform(Platform platform);
    }
}
