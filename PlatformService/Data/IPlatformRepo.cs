using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAll();

        Platform Get(int id);

        void Delete(int id);

        void CreatePlatform(Platform platform);
    }
}
